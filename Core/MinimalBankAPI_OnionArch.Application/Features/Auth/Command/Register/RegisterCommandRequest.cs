using MediatR;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest: IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
