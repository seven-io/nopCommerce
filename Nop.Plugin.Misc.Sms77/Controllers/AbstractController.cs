using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Models;
using Renci.SshNet.Messages.Authentication;

namespace Nop.Plugin.Misc.Sms77.Controllers {
    [AutoValidateAntiforgeryToken]
    public abstract class AbstractController : BasePluginController {
        #region Fields

        protected readonly ILocalizationService LocalizationService;
        protected readonly INotificationService NotificationService;
        protected readonly ISettingService SettingService;
        protected readonly IStoreContext StoreContext;
        protected readonly int StoreId;

        #endregion

        #region Ctor

        protected AbstractController(
            IStoreContext storeContext,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService
        ) {
            StoreContext = storeContext;
            SettingService = settingService;
            NotificationService = notificationService;
            LocalizationService = localizationService;

            StoreId = StoreContext.ActiveStoreScopeConfiguration;
        }

        #endregion

        #region Utilities

        protected Sms77Settings GetPluginSettings() {
            return SettingService.LoadSetting<Sms77Settings>(StoreId);
        }

        protected IActionResult ToView(string templateName, BaseNopModel model) {
            return View($"~/Plugins/Misc.Sms77/Views/{templateName}.cshtml", model);
        }

        protected void SuccessNotification(string resourceKey) {
            NotificationService.SuccessNotification(LocalizationService.GetResource(resourceKey));
        }

        #endregion
    }
}