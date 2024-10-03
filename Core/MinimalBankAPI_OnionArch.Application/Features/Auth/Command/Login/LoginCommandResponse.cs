using MinimalBankAPI_OnionArch.Security.JWT;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Login
{
    public class LoginCommandResponse
    {
        public Guid CustomerId { get; set; }
        public AccessToken AccessToken { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> Roles { get; set; }
    }
}
