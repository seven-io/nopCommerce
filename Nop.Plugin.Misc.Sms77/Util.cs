using System;
using System.Xml;

namespace Nop.Plugin.Misc.Sms77 {
    public static class Util {
        public static bool IsValidXml(string text) {
            try {
                new XmlDocument().LoadXml(text);

                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public static bool IsNumeric(string text) => uint.TryParse(text, out _);
    }
}