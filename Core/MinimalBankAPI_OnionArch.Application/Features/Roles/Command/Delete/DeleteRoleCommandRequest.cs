using MediatR;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Delete
{
    public class DeleteRoleCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
