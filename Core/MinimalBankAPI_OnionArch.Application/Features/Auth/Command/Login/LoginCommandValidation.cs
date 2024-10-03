using FluentValidation;


namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Login
{
    public class LoginCommandValidation : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.IdentityNumber)
              .NotEmpty().WithMessage("Identity Number boş olamaz.")
              .Length(11).WithMessage("Identity Number 11 karakter olmalıdır.")
              .Matches(@"^\d+$").WithMessage("Identity Number sadece sayı içermelidir.");


            RuleFor(x => x.Password).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(6);
        }
    }
}
