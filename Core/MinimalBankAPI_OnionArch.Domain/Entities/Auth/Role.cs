using MinimalBankAPI_OnionArch.Domain.Common;

namespace MinimalBankAPI_OnionArch.Domain.Entities.Auth
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string? Alias { get; set; }
        public string? Description { get; set; }
        public ICollection<CustomerRole> CutomerRoles { get; set; }
        public ICollection<RoleOperationClaim> RoleOperationClaims { get; set; }
    }


}
