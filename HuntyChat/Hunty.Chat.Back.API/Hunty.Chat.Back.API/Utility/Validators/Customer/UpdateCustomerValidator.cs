using FluentValidation;
using Hunty.Chat.Back.API.Utility.Constants;
using Hunty.Chat.Transverse.Models.Request.Customer;

namespace Hunty.Chat.Back.API.Utility.Validators.Customer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.PhoneNumber);

            RuleFor(x => x.IdCity)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);
        }
    }
}
