using MediatR;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Pagination;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Response;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryRequest : IRequest<GetListResponse<GetAllRolesQueryResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
