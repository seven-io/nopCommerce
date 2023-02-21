using FluentValidation;
using Nop.Plugin.Misc.Seven.Models;

namespace Nop.Plugin.Misc.Seven.Validators {
    public partial class VoiceValidator : BaseAbstractMessageValidator<VoiceModel> {
        public VoiceValidator() : base(10000) {
            RuleFor(m => m.Text)
                .Must(Util.IsValidXml)
                .When(m => m.Xml);
        }
    }
}