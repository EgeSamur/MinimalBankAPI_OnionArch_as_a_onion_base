using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Persistance.Context;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete.Base;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
