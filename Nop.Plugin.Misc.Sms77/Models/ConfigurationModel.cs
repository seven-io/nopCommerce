using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>
    /// Represents a configuration model
    /// </summary>
    public class ConfigurationModel : BaseNopModel {
        #region Ctor

        #endregion

        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Sms77.General.ApiKey")]
        public string ApiKey { get; set; }

        #endregion
    }
}