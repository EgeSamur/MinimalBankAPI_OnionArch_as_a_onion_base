using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Rules;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Delete
{
    public class DeleteRoleCommandHandler : BaseHandler, IRequestHandler<DeleteRoleCommandRequest, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleRules _roleRules;
        public DeleteRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, RoleRules roleRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleRepository = roleRepository;
            _roleRules = roleRules;
        }

        public async Task<Unit> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetAsync(predicate: i => i.Id == request.Id,
                enableTracking:true);
            await _roleRules.EnsureRoleExists(role);

            role.IsDeleted = true;
            role.DeletedDate = DateTimeOffset.UtcNow;
            role.DeletedBy = string.IsNullOrEmpty(_userId) ? (Guid?)null : Guid.Parse(_userId);
            
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
