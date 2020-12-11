﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Plugin.Misc.Sms77.Domain;
using Nop.Plugin.Misc.Sms77.Models;
using Nop.Plugin.Misc.Sms77.Services;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Sms77.Api;
using Sms77.Api.Library;

namespace Nop.Plugin.Misc.Sms77.Controllers {
    [Area(AreaNames.Admin)]
    [AuthorizeAdmin]
    [AutoValidateAntiforgeryToken]
    public abstract class AbstractBulkController<T> : AbstractBaseController where T : AbstractMessageModel {
        #region Ctor

        protected AbstractBulkController(
            IStoreContext storeContext,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService,
            ICustomerService customerService,
            ISmsService smsService,
            string templateName
        ) : base(storeContext, settingService, notificationService, localizationService) {
            _customerService = customerService;
            _smsService = smsService;
            _templateName = templateName;
        }

        #endregion

        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ISmsService _smsService;
        private readonly string _templateName;

        #endregion

        #region Methods

        public IActionResult Bulk() {
            var settings = GetPluginSettings();

            if (string.IsNullOrEmpty(settings.ApiKey)) {
                return Redirect($"{Sms77Plugin.ConfigurePath}?autofocus=ApiKey");
            }

            var model = new MessageModel {
                ActiveStoreScopeConfiguration = StoreId,
                From = settings.From,
                Sent = _smsService.GetAll(),
                Text = LocalizationService.GetResource("Plugins.Misc.Sms77.Message.Text.Placeholder")
            };

            foreach (var role in _customerService.GetAllCustomerRoles(true)) {
                model.AvailableCustomerRoles.Add(new SelectListItem(role.Name, role.Id.ToString()));
            }

            return ToView($"Bulk/{_templateName}",
                JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(model)));
        }

        [HttpPost]
        [FormValueRequired("save")]
        [ActionName("Bulk")]
        public abstract Task<IActionResult> Bulk(T model);

        protected async Task<IActionResult> Submit<TP>(
            T model,
            Func<Client, TP, Task<dynamic>> clientMethod,
            bool multipleRecipients
        ) where TP : new() {
            if (!ModelState.IsValid) {
                return Bulk();
            }

            var personalizer = new Personalizer(model.Text);
            var methodParamsList = new List<SmsParams>();

            foreach (var customer in
                _customerService.GetAllCustomers(customerRoleIds: model.SelectedCustomerRoleIds.ToArray())) {
                var addressId = customer.ShippingAddressId ?? customer.BillingAddressId;

                if (addressId.HasValue) {
                    var address = _customerService.GetCustomerAddress(customer.Id, addressId.Value);

                    model.To += $"{address.PhoneNumber},";

                    if (personalizer.HasPlaceholders) {
                        methodParamsList.Add(new SmsParams {
                            From = model.From,
                            Text = personalizer.Transform(customer, address),
                            To = address.PhoneNumber
                        });
                    }
                }
            }

            model.To = model.To.TrimEnd(',');

            var client = new Client(GetPluginSettings().ApiKey, "nopCommerce");

            if (0 == methodParamsList.Count) {
                methodParamsList.AddRange(
                    from to in multipleRecipients ? new[] {model.To} : model.To.Split(',')
                    select new SmsParams {From = model.From, Text = model.Text, To = to});
            }

            foreach (var paras in methodParamsList) {
                var res = await clientMethod(client,
                    JsonConvert.DeserializeObject<TP>(JsonConvert.SerializeObject(paras)));

                _smsService.Log(new SmsRecord {
                    Config = JsonConvert.SerializeObject(paras, Formatting.None, new JsonSerializerSettings {
                        NullValueHandling = NullValueHandling.Ignore
                    }),
                    Response = res is string ? res : JsonConvert.SerializeObject(res)
                });
            }

            return Bulk();
        }

        #endregion
    }
}