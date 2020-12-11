using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>Represents Voice model</summary>
    public class VoiceModel : AbstractMessageModel<VoiceRecord> {
        #region Ctor

        public VoiceModel() : base("Voice") { }

        #endregion
    }
}