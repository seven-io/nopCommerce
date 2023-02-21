using Nop.Plugin.Misc.Seven.Domain;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Seven.Models {
    /// <summary>Represents Voice model</summary>
    public class VoiceModel : AbstractMessageModel<VoiceRecord> {
        #region Ctor

        public VoiceModel() : base("Voice") { }

        #endregion
        
        #region Properties
        
        [NopResourceDisplayName("Plugins.Misc.Seven.Bulk.Voice.Xml")]
        public bool Xml { get; set; }
        
        #endregion
    }
}