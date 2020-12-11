using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.Sms77.Domain;
using Nop.Plugin.Misc.Sms77.Models;
using Nop.Plugin.Misc.Sms77.Services.Voice;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Sms77.Api.Library;

namespace Nop.Plugin.Misc.Sms77.Controllers {
    [AutoValidateAntiforgeryToken]
    public class VoiceController : AbstractBulkController<VoiceModel,VoiceRecord> {
        #region Ctor

        public VoiceController(
            IStoreContext storeContext,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService,
            ICustomerService customerService,
            IVoiceService voiceService
        ) : base(
            storeContext,
            settingService,
            notificationService,
            localizationService,
            customerService,
            voiceService,
            "Voice") { }

        #endregion

        #region Methods

        public override async Task<IActionResult> Bulk(VoiceModel model) {
            return await Submit<VoiceParams>(
                model,
                async (client, paras, record) => {
                    paras.Xml = model.Xml;
                    
                    Voice res = await client.Voice(paras, true);
                    
                    record.Code = res.Code;
                    record.Cost = res.Cost;
                    record.Sms77Id = res.Id;
                    
                    return (paras, record);
                },
                false);
        }

        #endregion
    }
}