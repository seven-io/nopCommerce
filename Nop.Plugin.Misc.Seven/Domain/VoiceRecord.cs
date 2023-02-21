namespace Nop.Plugin.Misc.Seven.Domain {
    /// <summary>Represents a voice message</summary>
    public partial class VoiceRecord : AbstractMessageRecord {
        /// <summary>Gets or sets the code</summary>
        public ushort? Code { get; set; }

        /// <summary>Gets or sets the seven id</summary>
        public uint? SevenId { get; set; }

        /// <summary>Gets or sets the cost</summary>
        public double? Cost { get; set; }
    }
}