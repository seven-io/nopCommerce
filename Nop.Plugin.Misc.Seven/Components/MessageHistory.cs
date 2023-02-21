using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.Seven.Domain;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.Seven.Components {
    public class AbstractMessageHistoryViewComponentData<TRecord> where TRecord : AbstractMessageRecord {
        public List<string> Headers { get; set; }
        public IList<TRecord> Messages { get; set; }
        public Func<TRecord, List<object>> RowHandler { get; set; }
    }

    [ViewComponent(Name = "MessageHistory")]
    public abstract class MessageHistoryViewComponent<TRecord> : NopViewComponent
        where TRecord : AbstractMessageRecord {
        public IViewComponentResult Invoke(AbstractMessageHistoryViewComponentData<TRecord> data) {
            return View("~/Plugins/Misc.Seven/Views/Shared/Components/MessageHistory/Default.cshtml", data);
        }
    }

    public class VoiceMessageHistoryViewComponent : MessageHistoryViewComponent<VoiceRecord> { }

    public class SmsMessageHistoryViewComponent : MessageHistoryViewComponent<SmsRecord> { }
}