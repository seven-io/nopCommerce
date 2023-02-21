using Nop.Data.Mapping;
using Nop.Plugin.Misc.Seven.Domain;
using System;
using System.Collections.Generic;

namespace Nop.Plugin.Misc.Seven.Data {
    public partial class BaseNameCompatibility : INameCompatibility {
        public Dictionary<Type, string> TableNames => new Dictionary<Type, string> {
            {typeof(SmsRecord), "Seven_Sms"},
            {typeof(VoiceRecord), "Seven_Voice"},
        };

        public Dictionary<(Type, string), string> ColumnName => new Dictionary<(Type, string), string>();
    }
}