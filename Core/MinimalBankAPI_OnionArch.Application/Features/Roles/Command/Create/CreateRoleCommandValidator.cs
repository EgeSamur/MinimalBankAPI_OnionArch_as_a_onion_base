using FluentValidation;

namespace MinimalBankAPI_OnionArch.Application.Features.Role.Command.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommandRequest>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.Alias).MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}
