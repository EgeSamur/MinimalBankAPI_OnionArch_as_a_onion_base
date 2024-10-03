using MinimalBankAPI_OnionArch.Domain.Common;

namespace MinimalBankAPI_OnionArch.Domain.Entities.Auth
{
    public class RoleOperationClaim : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }


}
