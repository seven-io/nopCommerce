using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Data;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Services.Sms {
    public class SmsService : ISmsService {
        private readonly IRepository<SmsRecord> _repository;

        public SmsService(IRepository<SmsRecord> repository) {
            _repository = repository;
        }

        public virtual void Log(SmsRecord record) {
            if (null == record) {
                throw new ArgumentNullException(nameof(record));
            }

            _repository.Insert(record);
        }

        public IList<SmsRecord> GetAll() {
            return _repository.Table.ToList();
        }
    }
}