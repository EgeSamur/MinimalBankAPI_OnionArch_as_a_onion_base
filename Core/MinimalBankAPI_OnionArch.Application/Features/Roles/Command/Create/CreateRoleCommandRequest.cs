using MediatR;

namespace MinimalBankAPI_OnionArch.Application.Features.Role.Command.Create
{
    public class CreateRoleCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string? Alias { get; set; }
        public string? Description { get; set; }
    }
}
