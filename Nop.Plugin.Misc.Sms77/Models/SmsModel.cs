using Nop.Plugin.Misc.Sms77.Domain;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>Represents SMS model</summary>
    public class SmsModel : AbstractMessageModel<SmsRecord> {
        #region Ctor

        public SmsModel() : base("Sms") { }

        #endregion

        #region Properties

        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Debug")]
        public bool Debug { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Delay")]
        public string Delay { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Flash")]
        public bool Flash { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.ForeignId")]
        public string ForeignId { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Label")]
        public string Label { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.NoReload")]
        public bool NoReload { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.PerformanceTracking")]
        public bool PerformanceTracking { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Ttl")]
        public int Ttl { get; set; } = 2880;
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Udh")]
        public string Udh { get; set; }
            
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Unicode")]
        public bool Unicode { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Sms.Utf8")]
        public bool Utf8 { get; set; }

        #endregion
    }
}