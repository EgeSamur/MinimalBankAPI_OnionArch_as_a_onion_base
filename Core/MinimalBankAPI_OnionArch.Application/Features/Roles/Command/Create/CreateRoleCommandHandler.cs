using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Rules;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;

namespace MinimalBankAPI_OnionArch.Application.Features.Role.Command.Create
{
    public class CreateRoleCommandHandler : BaseHandler, IRequestHandler<CreateRoleCommandRequest, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleRules _roleRules;
        public CreateRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IRoleRepository roleRepository, RoleRules roleRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _roleRepository = roleRepository;
            _roleRules = roleRules;
        }

        public async Task<Unit> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _roleRepository.GetAsync(predicate: i => i.Name == request.Name);
            await _roleRules.EnsureRolerNotExists(data);

            // create data 
            var role = _mapper.Map<Domain.Entities.Auth.Role>(request);
            role.Id = Guid.NewGuid();
            role.CreatedBy = string.IsNullOrEmpty(_userId) ? (Guid?)null : Guid.Parse(_userId);
            
            await _roleRepository.AddAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
