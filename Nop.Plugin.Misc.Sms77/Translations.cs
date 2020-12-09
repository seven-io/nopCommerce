using System.Collections.Generic;

namespace Nop.Plugin.Misc.Sms77 {
    public static class Translations {
        public static readonly Dictionary<string, string> English = new Dictionary<string, string> {
            ["Plugins.Misc.Sms77.Bulk.Sms"] = "Bulk SMS",
            ["Plugins.Misc.Sms77.Bulk.History"] = "History",
            ["Plugins.Misc.Sms77.Bulk.ID"] = "ID",
            ["Plugins.Misc.Sms77.Bulk.Config"] = "Config",
            ["Plugins.Misc.Sms77.Bulk.Response"] = "Response",
            ["Plugins.Misc.Sms77.Bulk.Sent"] = "Bulk Message(s) successfully dispatched!",

            ["Plugins.Misc.Sms77.General"] = "General",
            ["Plugins.Misc.Sms77.General.ApiKey"] = "API Key",
            ["Plugins.Misc.Sms77.General.ApiKeyPlaceholder"] = "My Super Secret Sms77.io Api Key",
            ["Plugins.Misc.Sms77.General.CopyPasteKeySave"] =
                "Copy and paste it into the field below and click save",
            ["Plugins.Misc.Sms77.General.CreateAccount"] = "Create a Sms77.io account",
            ["Plugins.Misc.Sms77.General.CreateKey"] = "Create Key",
            ["Plugins.Misc.Sms77.General.From"] = "From (sender) - defaults to the shop name",
            ["Plugins.Misc.Sms77.General.GetApiKey"] = "How to get an API Key?",

            ["Plugins.Misc.Sms77.Message.From"] = "From",
            ["Plugins.Misc.Sms77.Message.Text"] = "Message Text",
            ["Plugins.Misc.Sms77.Message.Text.Placeholder"] =
                "Hi {Username}. We have a store opening soon in your city {Address.City}!",
            ["Plugins.Misc.Sms77.Message.To"] = "Message Recipient",
        };
    }
}