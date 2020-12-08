using Nop.Core;

namespace Nop.Plugin.Misc.Sms77.Domain
{
    /// <summary>
    /// Represents a sms
    /// </summary>
    public partial class SmsRecord : BaseEntity
    {
        public SmsRecord()
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="config">Config</param>
        /// <param name="response">Response</param>
        public SmsRecord(string config, string response)
        {
            Config = config;
            Response = response;
        }

        /// <summary>
        /// Gets or sets the config
        /// </summary>
        public string Config { get; set; }

        /// <summary>
        /// Gets or sets the response
        /// </summary>
        public string Response { get; set; }
    }
}