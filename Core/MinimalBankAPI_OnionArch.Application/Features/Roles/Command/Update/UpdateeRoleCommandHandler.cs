using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Rules;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Update
{
    public class UpdateeRoleCommandHandler : BaseHandler, IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleRules _roleRules;
        public UpdateeRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, RoleRules roleRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleRepository = roleRepository;
            _roleRules = roleRules;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetAsync(predicate: i => i.Id == request.Id
               );
            await _roleRules.EnsureRoleExists(role);

            // create data 
            var updatedRole = _mapper.Map<Domain.Entities.Auth.Role>(request);
            updatedRole.UpdatedBy = string.IsNullOrEmpty(_userId) ? (Guid?)null : Guid.Parse(_userId);
            updatedRole.UpdatedDate = DateTimeOffset.UtcNow;
            role = updatedRole;

            var response = _mapper.Map<UpdateRoleCommandResponse>(role);
            // çok doğru bir yaklaşım değil !
            await _roleRepository.UpdateAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return response;
        }
    }
}
