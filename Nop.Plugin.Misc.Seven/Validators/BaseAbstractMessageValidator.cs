using FluentValidation;
using Nop.Plugin.Misc.Seven.Models;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Misc.Seven.Validators {
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