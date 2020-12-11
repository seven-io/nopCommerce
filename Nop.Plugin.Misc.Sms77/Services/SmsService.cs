using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Data;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Services {
    public interface ISmsService {
        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        void Log(SmsRecord record);
        
        IList<SmsRecord> GetAll();
    }

    public class SmsService : ISmsService {
        private readonly IRepository<SmsRecord> _smsRecordRepository;

        public SmsService(IRepository<SmsRecord> smsRecordRepository) {
            _smsRecordRepository = smsRecordRepository;
        }

        /// <summary>
        /// Logs the specified record.
        /// </summary>
        /// <param name="record">The record.</param>
        public virtual void Log(SmsRecord record) {
            if (null == record) {
                throw new ArgumentNullException(nameof(record));
            }

            _smsRecordRepository.Insert(record);
        }
        
        public IList<SmsRecord> GetAll() {
            return _smsRecordRepository.Table.ToList();
        }
    }
}