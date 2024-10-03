using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Alias)
                .HasMaxLength(50);

            builder.Property(r => r.Description)
                .HasMaxLength(250);

            // One-to-Many with CustomerRole
            builder.HasMany(r => r.CutomerRoles)
                .WithOne(cr => cr.Role)
                .HasForeignKey(cr => cr.RoleId);

            // One-to-Many with RoleOperationClaim
            builder.HasMany(r => r.RoleOperationClaims)
                .WithOne(roc => roc.Role)
                .HasForeignKey(roc => roc.RoleId);
        }
    }


}
