using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Rules;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly AuthRules _authRules;
        public RevokeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ICustomerRepository customerRepository, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _customerRepository = customerRepository;
            _authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(predicate: i => i.EmailAddress == request.Email,
                include: i => i.Include(x=>x.RefreshToken),
                enableTracking:true);
            await _authRules.EnsureCustoemrExists(customer);
            customer.RefreshToken = null;
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
