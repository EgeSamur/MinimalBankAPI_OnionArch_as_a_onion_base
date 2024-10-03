using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Delete;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Rules;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryHandler : BaseHandler, IRequestHandler<GetRoleByIdQueryRequest, GetRoleByIdQueryResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleRules _roleRules;

        public GetRoleByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, RoleRules roleRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleRepository = roleRepository;
            _roleRules = roleRules;
        }

        public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetAsync(x => x.Id == request.Id);
            await _roleRules.EnsureRoleExists(role);
            var response = _mapper.Map<GetRoleByIdQueryResponse>(role);
            return response;

        }
    }
}
