using System.Collections.Generic;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>Represents abstract message model</summary>
    public abstract class AbstractMessageModel<T> : BaseAbstractMessageModel where T : AbstractMessageRecord {
        #region Ctor

        protected AbstractMessageModel(string controllerName) : base(controllerName) {
            Sent = new List<T>();
        }

        #endregion

        #region Properties

        public new IList<T> Sent { get; set; }

        #endregion
    }
}