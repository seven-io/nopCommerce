using System.Collections.Generic;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Services.Voice {
    public interface IVoiceService : IMessageService<VoiceRecord> {
        new void Log(VoiceRecord record);

        new IList<VoiceRecord> GetAll();
    }
}