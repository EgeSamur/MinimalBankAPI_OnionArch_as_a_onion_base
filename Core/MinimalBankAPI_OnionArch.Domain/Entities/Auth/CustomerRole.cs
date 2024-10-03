using MinimalBankAPI_OnionArch.Domain.Common;

namespace MinimalBankAPI_OnionArch.Domain.Entities.Auth
{
    public class CustomerRole : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }


}
