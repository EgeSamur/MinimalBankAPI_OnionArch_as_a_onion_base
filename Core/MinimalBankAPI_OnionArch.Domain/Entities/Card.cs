using MinimalBankAPI_OnionArch.Domain.Common;

namespace MinimalBankAPI_OnionArch.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
 
    }



}
