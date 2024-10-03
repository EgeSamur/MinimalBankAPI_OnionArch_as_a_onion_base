using MinimalBankAPI_OnionArch.Domain.Common;

namespace MinimalBankAPI_OnionArch.Domain.Entities.Auth
{
    public class RefreshToken : BaseEntity
    {
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string Token { get; set; }
        public DateTime RefreshTokenExpirationTime { get; set; }
    }


}
