using Nop.Plugin.Misc.Seven.Domain;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Seven.Models {
    /// <summary>Represents SMS model</summary>
    public class SmsModel : AbstractMessageModel<SmsRecord> {
        #region Ctor

        public SmsModel() : base("Sms") { }

        #endregion

        #region Properties

        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Debug")]
        public bool Debug { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Delay")]
        public string Delay { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Flash")]
        public bool Flash { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.ForeignId")]
        public string ForeignId { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Label")]
        public string Label { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.NoReload")]
        public bool NoReload { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.PerformanceTracking")]
        public bool PerformanceTracking { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Ttl")]
        public int Ttl { get; set; } = 2880;
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Udh")]
        public string Udh { get; set; }
            
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Unicode")]
        public bool Unicode { get; set; }
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Sms.Utf8")]
        public bool Utf8 { get; set; }

        #endregion
    }
}