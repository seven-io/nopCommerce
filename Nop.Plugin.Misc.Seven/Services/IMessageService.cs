using System.Collections.Generic;
using Nop.Plugin.Misc.Seven.Domain;

namespace Nop.Plugin.Misc.Seven.Services {
    public interface IMessageService<T> where T : AbstractMessageRecord {
        /// <summary>Logs the specified record.</summary>
        /// <param name="record">The record to log.</param>
        void Log(T record);

        /// <summary>Retrieves all records.</summary>
        IList<T> GetAll();
    }
}