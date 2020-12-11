using Nop.Plugin.Misc.Sms77.Domain;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>Represents Voice model</summary>
    public class VoiceModel : AbstractMessageModel<VoiceRecord> {
        #region Ctor

        public VoiceModel() : base("Voice") { }

        #endregion
        
        #region Properties
        
        [NopResourceDisplayName("Plugins.Misc.Sms77.Bulk.Voice.Xml")]
        public bool Xml { get; set; }
        
        #endregion
    }
}