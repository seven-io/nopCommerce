using FluentValidation;
using Nop.Plugin.Misc.Sms77.Models;

namespace Nop.Plugin.Misc.Sms77.Validators {
    public partial class SmsValidator : BaseAbstractMessageValidator<SmsModel> {
        public SmsValidator() : base(1520) {
            RuleFor(m => m.From)
                .MaximumLength(11)
                .When(m => !Util.IsNumeric(m.From));
        }
    }
}