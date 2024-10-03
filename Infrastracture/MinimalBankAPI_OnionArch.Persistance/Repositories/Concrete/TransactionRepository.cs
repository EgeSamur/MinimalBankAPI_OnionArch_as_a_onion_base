using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Persistance.Context;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete.Base;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete
{
    public class TransactionRepository : BaseRepository<Transactionn>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
