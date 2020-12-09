using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.Sms77.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.Sms77.Controllers {
    [AutoValidateAntiforgeryToken]
    public class Sms77Controller : AbstractController {
        #region Ctor

        public Sms77Controller(
            IStoreContext storeContext,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService
        ) : base(storeContext, settingService, notificationService, localizationService) {}

        #endregion

        #region Methods

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult Configure() {
            return ToView("Configure", GetPluginSettings());
        }

        [AuthorizeAdmin, Area(AreaNames.Admin), HttpPost, ActionName("Configure")]
        [FormValueRequired("save")]
        public IActionResult Configure(Sms77Settings sms77Settings) {
            if (!ModelState.IsValid) {
                return Configure();
            }

            SettingService.SaveSetting(sms77Settings, settings => settings.ApiKey, clearCache: false);
            SettingService.SaveSetting(sms77Settings, settings => settings.From, clearCache: false);
            SettingService.ClearCache();

            SuccessNotification("Admin.Plugins.Saved");
            
            return Configure();
        }

        #endregion
    }
}