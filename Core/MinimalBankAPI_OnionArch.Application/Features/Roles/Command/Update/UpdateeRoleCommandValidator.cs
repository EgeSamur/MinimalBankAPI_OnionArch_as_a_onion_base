using FluentValidation;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Update
{
    public class UpdateeRoleCommandValidator : AbstractValidator<UpdateRoleCommandRequest>
    {
        public UpdateeRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.Alias).MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}
