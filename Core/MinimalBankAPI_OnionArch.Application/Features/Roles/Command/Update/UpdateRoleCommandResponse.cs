namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Update
{
    public class UpdateRoleCommandResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Alias { get; set; }
        public string? Description { get; set; }
    }
}
