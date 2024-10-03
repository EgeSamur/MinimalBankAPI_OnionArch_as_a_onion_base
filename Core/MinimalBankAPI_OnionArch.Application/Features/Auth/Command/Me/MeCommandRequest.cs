using MediatR;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Me
{
    public class MeCommandRequest: IRequest<MeCommandResponse>
    {
        public Guid CustomerId { get; set; }
    }
}
