using MinimalBankAPI_OnionArch.Domain.Common;

namespace MinimalBankAPI_OnionArch.Domain.Entities
{
    public class BankAccount: BaseEntity
    {
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Transactionn> Transactions { get; set; }
        public ICollection<Card> Cards { get; set; }

    }



}
