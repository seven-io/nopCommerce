using System.Collections.Generic;
using Nop.Plugin.Misc.Seven.Domain;

namespace Nop.Plugin.Misc.Seven.Models {
    /// <summary>Represents abstract message model</summary>
    public abstract class AbstractMessageModel<TRecord> : BaseAbstractMessageModel where TRecord : AbstractMessageRecord {
        #region Ctor

        protected AbstractMessageModel(string controllerName) : base(controllerName) {
            Sent = new List<TRecord>();
        }

        #endregion

        #region Properties

        public new IList<TRecord> Sent { get; set; }

        #endregion
    }
}