using Nop.Core;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Seven
{
    /// <summary>
    /// Represents a plugin settings
    /// </summary>
    public class SevenSettings : ISettings
    {
        #region Ctor

        public SevenSettings() {
            From = EngineContext.Current.Resolve<IStoreContext>().CurrentStore.CompanyName;
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets or sets the API key
        /// </summary>
        [NopResourceDisplayName("Plugins.Misc.Seven.General.ApiKey")] 
        public string ApiKey { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Seven.General.From")]
        public string From { get; set; }
        
        #endregion
    }
}