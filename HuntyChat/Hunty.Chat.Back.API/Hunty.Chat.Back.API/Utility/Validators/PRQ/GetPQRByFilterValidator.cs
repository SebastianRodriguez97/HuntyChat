using FluentValidation;
using Hunty.Chat.Back.API.Utility.Constants;
using Hunty.Chat.Transverse.Models.Request.PQR;

namespace Hunty.Chat.Back.API.Utility.Validators.PRQ
{
    public class GetPQRByFilterValidator : AbstractValidator<GetPQRByFilterRequest>
    {
        public GetPQRByFilterValidator()
        {
            RuleFor(x => x.From)
               .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
               .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.Until)
                .NotEmpty().WithMessage(ValidatorMessageConstants.NotEmpty)
                .NotNull().WithMessage(ValidatorMessageConstants.NotNull);

            RuleFor(x => x.IdCity);

            RuleFor(x => x.DocumentNumber);
        }
    }
}
