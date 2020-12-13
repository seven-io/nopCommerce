using FluentValidation;
using Nop.Plugin.Misc.Sms77.Models;

namespace Nop.Plugin.Misc.Sms77.Validators {
    public partial class VoiceValidator : BaseAbstractMessageValidator<VoiceModel> {
        public VoiceValidator() : base(10000) {
            RuleFor(m => m.Text)
                .Must(Util.IsValidXml)
                .When(m => m.Xml);
        }
    }
}