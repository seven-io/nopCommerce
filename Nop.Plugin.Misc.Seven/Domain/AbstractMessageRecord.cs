using Nop.Core;

namespace Nop.Plugin.Misc.Seven.Domain {
    /// <summary>Represents an abstract message</summary>
    public abstract class AbstractMessageRecord : BaseEntity {
        /// <summary>Gets or sets the config</summary>
        public string Config { get; set; }
    }
}