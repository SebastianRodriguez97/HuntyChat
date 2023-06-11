using FluentValidation;
using Hunty.Chat.Back.API.Utility.Constants;
using Hunty.Chat.Transverse.Models.Request.Customer;

namespace Hunty.Chat.Back.API.Utility.Validators.Customer
{
    public class GetCustomerByDocumentValidator : AbstractValidator<GetCustomerByDocumentRequest>
    {
        public GetCustomerByDocumentValidator()
        {
            RuleFor(x => x.DocumentCode)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);
        }
    }
}
