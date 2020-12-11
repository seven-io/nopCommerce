using System.Collections.Generic;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Services {
    public interface IMessageService<T> where T : AbstractMessageRecord {
        /// <summary>Logs the specified record.</summary>
        /// <param name="record">The record to log.</param>
        void Log(T record);

        /// <summary>Retrieves all records.</summary>
        IList<T> GetAll();
    }
}