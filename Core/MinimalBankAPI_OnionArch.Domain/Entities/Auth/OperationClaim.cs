using MinimalBankAPI_OnionArch.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalBankAPI_OnionArch.Domain.Entities.Auth
{
    public class OperationClaim : BaseEntity
    {
        public string Name { get; set; }
        public string? Alias { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public ICollection<RoleOperationClaim> RoleOperationClaims { get; set; }
    }


}
