using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Rules;
using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Security.JWT;
using System.Security.Claims;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly ITokenHelper _tokenService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly AuthRules _authRules;

        public RefreshTokenCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ITokenHelper tokenService, ICustomerRepository customerRepository, IRefreshTokenRepository refreshTokenRepository, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _tokenService = tokenService;
            _customerRepository = customerRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _authRules = authRules;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string? email = principal.FindFirst(ClaimTypes.Email).Value.ToString();


            Customer? customer = await _customerRepository.GetAsync(predicate: c => c.EmailAddress == email,
                include: i => i.Include(x => x.CustomerRoles)
                .ThenInclude(x => x.Role)
                .ThenInclude(x => x.RoleOperationClaims)
                .ThenInclude(x => x.OperationClaim)
                .Include(x=>x.RefreshToken),
                enableTracking: true);
            await _authRules.EnsureCustoemrExists(customer);

            await _authRules.EnsureCustomerNotLogOut(customer.RefreshToken.RefreshTokenExpirationTime);
            AccessToken createdAccessToken = _tokenService.CreateToken(customer!);

            // burası için bir mapper oluşturalabilir.
            customer.RefreshToken.Token = createdAccessToken.RefreshToken;
            customer.RefreshToken.RefreshTokenExpirationTime = createdAccessToken.RefreshTokenExpiration;
            customer.RefreshToken.UpdatedDate = DateTimeOffset.UtcNow;
            customer.RefreshToken.CustomerID = customer.Id;

            var result = new RefreshTokenCommandResponse()
            {
                AccessToken = createdAccessToken,
            };
            await _unitOfWork.SaveChangesAsync();
            return result;
            // customerın refresh Tokenini de güncelleyeceğiz.

        }
    }
}
