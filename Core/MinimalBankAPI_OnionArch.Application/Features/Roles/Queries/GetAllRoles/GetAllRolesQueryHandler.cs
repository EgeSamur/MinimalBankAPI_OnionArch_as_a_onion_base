using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Response;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : BaseHandler, IRequestHandler<GetAllRolesQueryRequest, GetListResponse<GetAllRolesQueryResponse>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleRepository = roleRepository;
        }

        public async Task<GetListResponse<GetAllRolesQueryResponse>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetListIPaginateAsync(size:request.PageSize,index:request.CurrentPage);
            var response = _mapper.Map<GetListResponse<GetAllRolesQueryResponse>>(roles);
            return response;
        }
    }
}
