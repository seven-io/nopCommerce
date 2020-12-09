using Nop.Core;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Sms77
{
    /// <summary>
    /// Represents a plugin settings
    /// </summary>
    public class Sms77Settings : ISettings
    {
        #region Ctor

        public Sms77Settings() {
            From = EngineContext.Current.Resolve<IStoreContext>().CurrentStore.CompanyName;
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets or sets the API key
        /// </summary>
        [NopResourceDisplayName("Plugins.Misc.Sms77.General.ApiKey")] 
        public string ApiKey { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.General.From")]
        public string From { get; set; }
        
        #endregion
    }
}