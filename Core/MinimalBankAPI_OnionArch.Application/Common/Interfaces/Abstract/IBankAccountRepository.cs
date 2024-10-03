using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalBankAPI_OnionArch.Persistance.Repositories.Abstract
{
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
    }
}
