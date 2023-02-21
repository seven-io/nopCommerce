using System.Collections.Generic;
using Nop.Plugin.Misc.Seven.Domain;

namespace Nop.Plugin.Misc.Seven.Services.Sms {
    public interface ISmsService : IMessageService<SmsRecord> {
        new void Log(SmsRecord record);

        new IList<SmsRecord> GetAll();
    }
}