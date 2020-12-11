using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.Sms77.Models;
using Nop.Plugin.Misc.Sms77.Services;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Sms77.Api.Library;

namespace Nop.Plugin.Misc.Sms77.Controllers {
    public class SmsController : AbstractBulkController<SmsModel> {
        #region Ctor

        public SmsController(
            IStoreContext storeContext,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService,
            ICustomerService customerService,
            ISmsService smsService
        ) : base(
            storeContext,
            settingService,
            notificationService,
            localizationService,
            customerService,
            smsService,
            "Sms") { }

        #endregion

        #region Methods

        public override async Task<IActionResult> Bulk(SmsModel model) {
            return await Submit<SmsParams>(
                model,
                (client, smsParams) => {
                    smsParams.Json = true;

                    return client.Sms(smsParams);
                },
                true);
        }

        #endregion
    }
}