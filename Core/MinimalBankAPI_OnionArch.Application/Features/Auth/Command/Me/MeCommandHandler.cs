using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Rules;
using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Me
{
    public class MeCommandHandler : BaseHandler, IRequestHandler<MeCommandRequest, MeCommandResponse>
    {
        private readonly AuthRules _authRules;
        private readonly ICustomerRepository _customerRepository;
        public MeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, AuthRules authRules, ICustomerRepository customerRepository) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            _customerRepository = customerRepository;
        }

        public async Task<MeCommandResponse> Handle(MeCommandRequest request, CancellationToken cancellationToken)
        {
            Customer? customer = await _customerRepository.GetAsync(predicate: i => i.Id == request.CustomerId,
               include: i => i.Include(x => x.CustomerRoles)
              .ThenInclude(x => x.Role)
              .ThenInclude(x => x.RoleOperationClaims)
              .ThenInclude(x => x.OperationClaim),
               enableTracking: true);

            await _authRules.EnsureCustoemrExists(customer);

            var rolePermissions = customer.CustomerRoles.SelectMany(x => x.Role.RoleOperationClaims).Select(x => x.OperationClaim.Name).ToList();
            var allPermissions = rolePermissions.Distinct().ToList();
            var roles = customer.CustomerRoles.Select(x => x.Role.Name).ToList();

            var resposne = _mapper.Map<MeCommandResponse>(customer);
            resposne.Roles = roles;
            resposne.Permissions = allPermissions;
            resposne.Username = $"{resposne.FirstName}_{resposne.LastName}";
            return resposne;
        }
    }
}
