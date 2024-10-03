using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class RoleOperationClaimConfiguration : IEntityTypeConfiguration<RoleOperationClaim>
    {
        public void Configure(EntityTypeBuilder<RoleOperationClaim> builder)
        {
            builder.HasKey(roc => roc.Id);

            builder.HasOne(roc => roc.Role)
                .WithMany(r => r.RoleOperationClaims)
                .HasForeignKey(roc => roc.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(roc => roc.OperationClaim)
                .WithMany(oc => oc.RoleOperationClaims)
                .HasForeignKey(roc => roc.OperationClaimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
