using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Data;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Services.Voice {
    public class VoiceService : IVoiceService {
        private readonly IRepository<VoiceRecord> _repository;

        public VoiceService(IRepository<VoiceRecord> repository) {
            _repository = repository;
        }

        public virtual void Log(VoiceRecord record) {
            if (null == record) {
                throw new ArgumentNullException(nameof(record));
            }

            _repository.Insert(record);
        }

        public IList<VoiceRecord> GetAll() {
            return _repository.Table.ToList();
        }
    }
}