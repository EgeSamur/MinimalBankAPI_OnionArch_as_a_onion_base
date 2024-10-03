using FluentValidation;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Me
{
    public class MeCommandValidation : AbstractValidator<MeCommandRequest>
    {
        public MeCommandValidation()
        {
            RuleFor(x => x.CustomerId)
              .NotEmpty();

        }
    }
}
