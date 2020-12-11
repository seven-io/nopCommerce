using System.Linq;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.Sms77 {
    /// <summary>
    /// Represents the Sms77 plugin
    /// </summary>
    public class Sms77Plugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin {
        #region Fields

        public const string ConfigurePath = "/Admin/Sms77/Configure";
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

        private void AddSiteMapChildNode(SiteMapNode node, string actionName, string controllerName, string title) {
            node.ChildNodes.Add(new SiteMapNode {
                ActionName = actionName,
                ControllerName = controllerName,
                SystemName = $"Misc.Sms77.{controllerName}.{actionName}",
                Title = $"Sms77 {_localizationService.GetResource(title)}",
                Visible = true,
            });
        }

        public void ManageSiteMap(SiteMapNode root) {
            var node = root.ChildNodes.FirstOrDefault(n => n.SystemName == "Third party plugins") ?? root;

            AddSiteMapChildNode(node, "Bulk", "Sms", "Plugins.Misc.Sms77.Bulk.Sms");
            AddSiteMapChildNode(node, "Bulk", "Voice", "Plugins.Misc.Sms77.Bulk.Voice");
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl() {
            return _webHelper.GetStoreLocation().TrimEnd('/') + ConfigurePath;
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