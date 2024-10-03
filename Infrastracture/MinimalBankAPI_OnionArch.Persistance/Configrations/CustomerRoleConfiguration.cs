using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class CustomerRoleConfiguration : IEntityTypeConfiguration<CustomerRole>
    {
        public void Configure(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.HasKey(cr => cr.Id);

            builder.HasOne(cr => cr.Customer)
                .WithMany(c => c.CustomerRoles)
                .HasForeignKey(cr => cr.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cr => cr.Role)
                .WithMany(r => r.CutomerRoles)
                .HasForeignKey(cr => cr.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
