using MinimalBankAPI_OnionArch.Domain.Entities;
using System.Security.Claims;

namespace MinimalBankAPI_OnionArch.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Customer customer);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
