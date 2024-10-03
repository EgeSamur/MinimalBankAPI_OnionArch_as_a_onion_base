using MinimalBankAPI_OnionArch.Domain.Entities.Auth;
using MinimalBankAPI_OnionArch.Persistance.Context;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete.Base;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete
{
    public class OperationClaimRepository : BaseRepository<OperationClaim>, IOperationClaimRepository
    {
        public OperationClaimRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
