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
    [AutoValidateAntiforgeryToken]
    public class VoiceController : AbstractBulkController<VoiceModel> {
        #region Ctor

        public VoiceController(
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
            "Voice") { }

        #endregion

        #region Methods

        public override async Task<IActionResult> Bulk(VoiceModel model) {
            return await Submit<VoiceParams>(
                model,
                (client, voiceParams) => client.Voice(voiceParams, true),
                false);
        }

        #endregion
    }
}