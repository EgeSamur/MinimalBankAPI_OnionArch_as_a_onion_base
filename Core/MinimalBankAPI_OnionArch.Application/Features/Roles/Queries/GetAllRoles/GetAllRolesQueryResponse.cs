using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Alias { get; set; }
        public string? Description { get; set; }
        public ICollection<RoleOperationClaim> RoleOperationClaims { get; set; }

    }
}