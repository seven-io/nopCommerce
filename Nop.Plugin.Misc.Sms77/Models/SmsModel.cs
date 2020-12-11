using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>Represents SMS model</summary>
    public class SmsModel : AbstractMessageModel<SmsRecord> {
        #region Ctor

        public SmsModel() : base("Sms") { }

        #endregion
    }
}