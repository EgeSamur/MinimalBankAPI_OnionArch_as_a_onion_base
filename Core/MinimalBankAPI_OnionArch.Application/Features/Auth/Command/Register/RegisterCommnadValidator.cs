using FluentValidation;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Register
{
    public class RegisterCommnadValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommnadValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
               .MaximumLength(50)
               .MinimumLength(2);

            RuleFor(x => x.LastName).NotEmpty()
             .MaximumLength(50)
             .MinimumLength(2);

            RuleFor(x => x.EmailAddress).NotEmpty()
              .EmailAddress()
              .MaximumLength(50)
              .MinimumLength(8);
            RuleFor(x => x.Password).NotEmpty()
              .MaximumLength(50)
              .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(6)
                .Equal(x => x.Password);

            RuleFor(x => x.IdentityNumber)
            .NotEmpty().WithMessage("Identity Number boş olamaz.")
            .Length(11).WithMessage("Identity Number 11 karakter olmalıdır.")
            .Matches(@"^\d+$").WithMessage("Identity Number sadece sayı içermelidir.");
           
            RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone Number boş olamaz")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Phone Number must be a valid number with 10 to 15 digits.");

        }
    }
}
