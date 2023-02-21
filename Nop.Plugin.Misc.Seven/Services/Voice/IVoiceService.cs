using System.Collections.Generic;
using Nop.Plugin.Misc.Seven.Domain;

namespace Nop.Plugin.Misc.Seven.Services.Voice {
    public interface IVoiceService : IMessageService<VoiceRecord> {
        new void Log(VoiceRecord record);

        new IList<VoiceRecord> GetAll();
    }
}