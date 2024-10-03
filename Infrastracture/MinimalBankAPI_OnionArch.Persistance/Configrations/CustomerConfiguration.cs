using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.EmailAddress)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.IdentityNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.PasswordHash)
                .IsRequired();

            builder.Property(c => c.PasswordSalt)
                .IsRequired();

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            // One-to-Many with BankAccount
            builder.HasMany(c => c.BankAccounts)
                .WithOne(ba => ba.Customer)
                .HasForeignKey(ba => ba.CustomerId);
         
        }
    }


}
