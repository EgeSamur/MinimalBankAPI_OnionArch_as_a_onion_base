using MinimalBankAPI_OnionArch.Domain.Common;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Domain.Entities
{
    public class Customer : BaseEntity
    {
      
        public string EmailAddress { get; set; }
        public string IdentityNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; } = true;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<CustomerRole> CustomerRoles { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
        public ICollection<Card> Cards { get; set; }

    }





}
