using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities.Auth;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Token)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(rt => rt.RefreshTokenExpirationTime)
                .IsRequired();

            // One-to-One relationship with Customer
            builder.HasOne(rt => rt.Customer)
                .WithOne(c => c.RefreshToken)
                .HasForeignKey<RefreshToken>(rt => rt.CustomerID);
        }
    }


}
