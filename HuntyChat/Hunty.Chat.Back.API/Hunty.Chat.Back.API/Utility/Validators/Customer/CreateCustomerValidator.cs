using FluentValidation;
using Hunty.Chat.Back.API.Utility.Constants;
using Hunty.Chat.Transverse.Models.Request.Customer;

namespace Hunty.Chat.Back.API.Utility.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.DocumentTypeCode)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.Birthday)
               .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
               .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.IdCity)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.PhoneNumber);
        }
    }
}
