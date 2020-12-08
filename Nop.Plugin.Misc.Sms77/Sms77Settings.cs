using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.Sms77
{
    /// <summary>
    /// Represents a plugin settings
    /// </summary>
    public class Sms77Settings : ISettings
    {
        /// <summary>
        /// Gets or sets the API key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the SMS sender name
        /// </summary>
        public string SmsSenderName { get; set; }

        /// <summary>
        /// Gets or sets the store owner phone number for SMS notifications
        /// </summary>
        public string StoreOwnerPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the Tracking script
        /// </summary>
        public string TrackingScript { get; set; }

        /// <summary>
        /// Gets or sets the Marketing Automation key (Tracker ID)
        /// </summary>
        public string MarketingAutomationKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use Marketing Automation
        /// </summary>
        public bool UseMarketingAutomation { get; set; }
    }
}