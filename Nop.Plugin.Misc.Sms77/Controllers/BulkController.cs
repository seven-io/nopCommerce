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
using StackExchange.Profiling.Internal;

namespace Nop.Plugin.Misc.Sms77.Controllers {
    [AutoValidateAntiforgeryToken]
    public class BulkController : AbstractController {
        #region Ctor

        public BulkController(
            IStoreContext storeContext,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService,
            ICustomerService customerService,
            ISmsService smsService
        ) : base(storeContext, settingService, notificationService, localizationService) {
            _customerService = customerService;
            _smsService = smsService;
        }

        #endregion

        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ISmsService _smsService;

        #endregion

        #region Methods

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult Sms() {
            var settings = GetPluginSettings();

            if (string.IsNullOrEmpty(settings.ApiKey)) {
                return Redirect("/Admin/Sms77/Configure?autofocus=ApiKey");
            }

            var model = new SmsModel {
                Sent = _smsService.GetAll(),
                ActiveStoreScopeConfiguration = StoreId,
                From = settings.From,
                Text = LocalizationService.GetResource("Plugins.Misc.Sms77.Message.Text.Placeholder")
            };

            foreach (var role in _customerService.GetAllCustomerRoles(true)) {
                model.AvailableCustomerRoles.Add(new SelectListItem(role.Name, role.Id.ToString()));
            }

            return ToView("BulkSms", model);
        }

        [AuthorizeAdmin, Area(AreaNames.Admin), HttpPost, ActionName("Sms"), FormValueRequired("save")]
        public async Task<IActionResult> Sms(SmsModel model) {
            if (!ModelState.IsValid) {
                return Sms();
            }

            var smsParamsList = new List<SmsParams>();
            var personalizer = new Personalizer(model.Text);

            foreach (var customer in
                _customerService.GetAllCustomers(customerRoleIds: model.SelectedCustomerRoleIds.ToArray())) {
                var addressId = customer.ShippingAddressId ?? customer.BillingAddressId;

                if (addressId.HasValue) {
                    var address = _customerService.GetCustomerAddress(customer.Id, addressId.Value);

                    model.To += $"{address.PhoneNumber},";

                    if (personalizer.HasPlaceholders) {
                        smsParamsList.Add(new SmsParams {
                            From = model.From,
                            To = address.PhoneNumber,
                            Text = personalizer.Transform(customer, address)
                        });
                    }
                }
            }

            if (model.To.EndsWith(',')) {
                model.To = model.To.Remove(model.To.Length - 1);
            }

            if (!personalizer.HasPlaceholders) {
                smsParamsList.Add(new SmsParams {From = model.From, Text = model.Text, To = model.To});
            }

            var client = new Client(GetPluginSettings().ApiKey, "nopCommerce");

            foreach (var smsParams in smsParamsList) {
                smsParams.Json = true;
                smsParams.From = model.From;

                var obj = await client.Sms(smsParams);
                var json = JsonConvert.SerializeObject(obj, Formatting.None);

                _smsService.Log(new SmsRecord {Config = smsParams.ToJson(), Response = json});
            }

            return Sms();
        }

        #endregion
    }
}