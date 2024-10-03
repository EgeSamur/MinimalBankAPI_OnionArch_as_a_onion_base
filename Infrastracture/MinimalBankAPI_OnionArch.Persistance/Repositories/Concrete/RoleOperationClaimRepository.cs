﻿using MinimalBankAPI_OnionArch.Domain.Entities.Auth;
using MinimalBankAPI_OnionArch.Persistance.Context;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete.Base;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Concrete
{
    public class RoleOperationClaimRepository : BaseRepository<RoleOperationClaim>, IRoleOperationClaimRepository
    {
        public RoleOperationClaimRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}