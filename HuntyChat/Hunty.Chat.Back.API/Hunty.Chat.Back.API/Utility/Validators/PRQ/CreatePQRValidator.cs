using FluentValidation;
using Hunty.Chat.Back.API.Utility.Constants;
using Hunty.Chat.Transverse.Models.Request.PQR;

namespace Hunty.Chat.Back.API.Utility.Validators.PRQ
{
    public class CreatePQRValidator : AbstractValidator<CreatePQRRequest>
    {
        public CreatePQRValidator()
        {
            RuleFor(x => x.Comment)
               .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
               .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.IdCustomer)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.PQRTypeCode)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);
        }
    }
}
