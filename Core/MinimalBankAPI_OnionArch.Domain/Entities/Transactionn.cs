using MinimalBankAPI_OnionArch.Domain.Common;
using MinimalBankAPI_OnionArch.Domain.Entities.Enums;

namespace MinimalBankAPI_OnionArch.Domain.Entities
{
    public class Transactionn : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }  // Enum type

        // Foreign key for BankAccount
        public Guid BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }



}
