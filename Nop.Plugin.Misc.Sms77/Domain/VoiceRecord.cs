namespace Nop.Plugin.Misc.Sms77.Domain {
    /// <summary>Represents a voice message</summary>
    public partial class VoiceRecord : AbstractMessageRecord {
        /// <summary>Gets or sets the code</summary>
        public ushort? Code { get; set; }

        /// <summary>Gets or sets the Sms77 id</summary>
        public uint? Sms77Id { get; set; }

        /// <summary>Gets or sets the cost</summary>
        public double? Cost { get; set; }
    }
}