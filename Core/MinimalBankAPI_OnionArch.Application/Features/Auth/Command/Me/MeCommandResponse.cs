namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Me
{
    public class MeCommandResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public List<string>? Roles { get; set; }
        public List<string>? Permissions { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }
        public bool Status { get; set; }

    }
}
