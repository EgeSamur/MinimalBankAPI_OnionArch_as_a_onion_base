using FluentValidation;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Delete
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommandRequest>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
