﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(oc => oc.Id);

            builder.Property(oc => oc.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(oc => oc.Alias)
                .HasMaxLength(50);

            builder.Property(oc => oc.Description)
                .HasMaxLength(250);

            builder.Property(oc => oc.Status)
                .IsRequired();

            // One-to-Many with RoleOperationClaim
            builder.HasMany(oc => oc.RoleOperationClaims)
                .WithOne(roc => roc.OperationClaim)
                .HasForeignKey(roc => roc.OperationClaimId);
        }
    }


}
