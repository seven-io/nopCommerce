using System.Collections.Generic;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Services.Sms {
    public interface ISmsService : IMessageService<SmsRecord> {
        new void Log(SmsRecord record);

        new IList<SmsRecord> GetAll();
    }
}