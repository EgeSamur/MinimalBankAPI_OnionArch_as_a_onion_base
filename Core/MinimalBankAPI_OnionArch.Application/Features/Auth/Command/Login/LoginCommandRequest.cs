using MediatR;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
    }
}
