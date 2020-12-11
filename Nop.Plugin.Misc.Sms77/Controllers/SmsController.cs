using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Plugin.Misc.Sms77.Domain;
using Nop.Plugin.Misc.Sms77.Models;
using Nop.Plugin.Misc.Sms77.Services.Sms;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Sms77.Api.Library;

namespace Nop.Plugin.Misc.Sms77.Controllers {
    public class SmsController : AbstractBulkController<SmsModel, SmsRecord> {
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
                async (client, paras, record) => {
                    paras.Json = true;

                    record.Response = JsonConvert.SerializeObject(await client.Sms(paras));

                    return (paras, record);
                },
                true);
        }

        #endregion
    }
}