using MediatR;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Delete;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
