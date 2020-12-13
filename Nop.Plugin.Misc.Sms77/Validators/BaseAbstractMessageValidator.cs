using FluentValidation;
using Nop.Plugin.Misc.Sms77.Models;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Misc.Sms77.Validators {
    public partial class BaseAbstractMessageValidator<T> : BaseNopValidator<T> where T : BaseAbstractMessageModel {
        protected BaseAbstractMessageValidator(ushort maxLength) {
            RuleFor(m => m.Text)
                .NotEmpty()
                .MaximumLength(maxLength);

            RuleFor(m => m.From)
                .MaximumLength(16);
        }
    }
}