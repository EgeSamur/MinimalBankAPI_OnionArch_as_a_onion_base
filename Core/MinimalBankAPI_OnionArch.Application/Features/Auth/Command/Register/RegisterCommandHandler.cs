using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Rules;
using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Security.Hashing;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ICardRepository _cardRepository;
        private readonly AuthRules _authRules;
        public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor, ICustomerRepository customerRepository,
            AuthRules authRules)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _customerRepository = customerRepository;
            _authRules = authRules;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            Customer? data = await _customerRepository.GetAsync(predicate: i => i.IdentityNumber == request.IdentityNumber,
                enableTracking:false);
            await _authRules.EnsureCustomerNotExists(data);

            // şu andan itibaren bir customer olmadığına eminiz.
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            Customer customer = _mapper.Map<Customer>(request);
            customer.Id = Guid.NewGuid();
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;

            // customer'a ait BankAccount ve Kard da oluşması gerekiyor. sonradan kart eklenebilir.
            // Ama burası şimdilik bir dursun.
            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return await Unit.Task;
        }
    }
}
