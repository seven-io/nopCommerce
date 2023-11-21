using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Plugin.Misc.Seven.Domain;
using Nop.Plugin.Misc.Seven.Models;
using Nop.Plugin.Misc.Seven.Services.Sms;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Sms77.Api.Library;

namespace Nop.Plugin.Misc.Seven.Controllers {
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

        public override async Task<IActionResult> Bulk(SmsModel m) {
            return await Submit<SmsParams>(
                m,
                async (client, p, record) => {
                    p.Json = true;
                    p.Delay = m.Delay;
                    p.Label = m.Label;
                    p.Flash = m.Flash;
                    p.ForeignId = m.ForeignId;
                    p.NoReload = m.NoReload;
                    p.PerformanceTracking = m.PerformanceTracking;
                    p.Ttl = m.Ttl;
                    p.Udh = m.Udh;
                    p.Unicode = m.Unicode;
                    p.Utf8 = m.Utf8;

                    record.Response = JsonConvert.SerializeObject(await client.Sms(p));

                    return (p, record);
                },
                true);
        }

        #endregion
    }
}
