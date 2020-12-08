using System.Collections.Generic;
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

            _localizationService.AddPluginLocaleResource(new Dictionary<string, string> {
                ["Plugins.Misc.Sms77.Bulk.Sms"] = "Bulk SMS",
                ["Plugins.Misc.Sms77.Bulk.History"] = "History",
                ["Plugins.Misc.Sms77.Bulk.ID"] = "ID",
                ["Plugins.Misc.Sms77.Bulk.Config"] = "Config",
                ["Plugins.Misc.Sms77.Bulk.Response"] = "Response",
                ["Plugins.Misc.Sms77.Bulk.Sent"] = "Bulk Message(s) successfully dispatched!",
                ["Plugins.Misc.Sms77.General"] = "General",
                ["Plugins.Misc.Sms77.General.ApiKey"] = "API Key",
                ["Plugins.Misc.Sms77.General.ApiKeyPlaceholder"] = "My Super Secret Sms77.io Api Key",
                ["Plugins.Misc.Sms77.General.CopyPasteKeySave"] =
                    "Copy and paste it into the field below and click save",
                ["Plugins.Misc.Sms77.General.CreateAccount"] = "Create a Sms77.io account",
                ["Plugins.Misc.Sms77.General.CreateKey"] = "Create Key",
                ["Plugins.Misc.Sms77.General.GetApiKey"] = "How to get an API Key?",
                ["Plugins.Misc.Sms77.Message.CustomerRoles"] = "Customer Roles",
                ["Plugins.Misc.Sms77.Message.From"] = "From",
                ["Plugins.Misc.Sms77.Message.Text"] = "Message Text",
                ["Plugins.Misc.Sms77.Message.To"] = "Message Recipient",
            });

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