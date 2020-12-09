using System.Linq;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.Sms77 {
    /// <summary>
    /// Represents the Sms77 plugin
    /// </summary>
    public class Sms77Plugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public Sms77Plugin(
            ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper
        ) {
            _localizationService = localizationService;
            _settingService = settingService;
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        public void ManageSiteMap(SiteMapNode rootNode) {
            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");

            (pluginNode ?? rootNode).ChildNodes.Add(new SiteMapNode {
                ActionName = "Sms",
                ControllerName = "Bulk",
                RouteValues = new RouteValueDictionary {{"area", AreaNames.Admin}},
                SystemName = "Misc.Sms77",
                Title = "Sms77 BulkSMS",
                Visible = true,
            });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl() {
            return $"{_webHelper.GetStoreLocation()}Admin/Sms77/Configure";
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install() {
            _settingService.SaveSetting(new Sms77Settings());

            _localizationService.AddPluginLocaleResource(Translations.English);

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall() {
            _settingService.DeleteSetting<Sms77Settings>();

            _localizationService.DeletePluginLocaleResources("Plugins.Misc.Sms77");

            base.Uninstall();
        }

        #endregion
    }
}