using Nop.Data.Mapping;
using Nop.Plugin.Misc.Sms77.Domain;
using System;
using System.Collections.Generic;

namespace Nop.Plugin.Misc.Sms77.Data {
    public partial class BaseNameCompatibility : INameCompatibility {
        public Dictionary<Type, string> TableNames => new Dictionary<Type, string> {
            {typeof(SmsRecord), "Sms77_Sms"},
        };

        public Dictionary<(Type, string), string> ColumnName => new Dictionary<(Type, string), string>();
    }
}