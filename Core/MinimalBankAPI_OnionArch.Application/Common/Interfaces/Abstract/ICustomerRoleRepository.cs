﻿using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract.Base;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract
{
    public interface ICustomerRoleRepository : IRepository<CustomerRole>
    {
    }
}
