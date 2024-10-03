using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Alias { get; set; }
        public string? Description { get; set; }
        public ICollection<RoleOperationClaim> RoleOperationClaims { get; set; }
    }
}