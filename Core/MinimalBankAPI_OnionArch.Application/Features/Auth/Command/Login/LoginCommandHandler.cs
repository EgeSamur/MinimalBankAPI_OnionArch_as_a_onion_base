using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalBankAPI_OnionArch.Application.Common.BaseHandler;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Rules;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Security.JWT;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly AuthRules _authRules;
        private readonly ITokenHelper _tokenService;
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LoginCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            AuthRules authRules, ITokenHelper tokenService, IConfiguration configuration,
            ICustomerRepository customerRepository, IRefreshTokenRepository refreshTokenRepository)
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            _tokenService = tokenService;
            _configuration = configuration;
            _customerRepository = customerRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer? customer = await _customerRepository.GetAsync(predicate: i => i.IdentityNumber == request.IdentityNumber,
                 include: i => i.Include(x => x.CustomerRoles)
                .ThenInclude(x => x.Role)
                .ThenInclude(x => x.RoleOperationClaims)
                .ThenInclude(x => x.OperationClaim)
                .Include(x=>x.RefreshToken),
                 enableTracking:true);

            await _authRules.EnsureCustoemrExists(customer);
            await _authRules.EnsurePasswordIsCorrect(customer!, request.Password);

            //customer var reisoya token verecepiz.
            var rolePermissions = customer.CustomerRoles.SelectMany(x => x.Role.RoleOperationClaims).Select(x => x.OperationClaim.Name).ToList();
            var allPermissions = rolePermissions.Distinct().ToList();
            var roles = customer.CustomerRoles.Select(x => x.Role.Name).ToList();

            AccessToken createdAccessToken = _tokenService.CreateToken(customer!);
            var result = new LoginCommandResponse
            {
                CustomerId = customer.Id,
                Roles = roles,
                AccessToken = createdAccessToken,
                Permissions = allPermissions,
            };
            if (customer.RefreshToken.Token is null) // ilk kez login yapıyorsa eğer.
            {
                var refreshToken = new Domain.Entities.Auth.RefreshToken
                {
                    Id = Guid.NewGuid(),
                    CustomerID = customer.Id,
                    RefreshTokenExpirationTime = result.AccessToken.RefreshTokenExpiration,
                    Token = result.AccessToken.RefreshToken,
                };

                await _refreshTokenRepository.AddAsync(refreshToken);

            }
            else
            {
                // her giriş yaptığında yeni token ve refresh token oluşturyor db den de güncellenmeli
                customer.RefreshToken.CustomerID = customer.Id;
                customer.RefreshToken.Token = createdAccessToken.RefreshToken;
                customer.RefreshToken.RefreshTokenExpirationTime = createdAccessToken.RefreshTokenExpiration;
                customer.RefreshToken.UpdatedDate = DateTimeOffset.UtcNow;
            }
            await _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
