using MinimalBankAPI_OnionArch.Security.JWT;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}
