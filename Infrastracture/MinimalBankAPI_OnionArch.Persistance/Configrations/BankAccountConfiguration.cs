using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.Id);

            builder.Property(ba => ba.AccountNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(ba => ba.IBAN)
                .IsRequired()
                .HasMaxLength(34);

            builder.Property(ba => ba.Balance)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            // One-to-Many with Transactions
            builder.HasMany(ba => ba.Transactions)
                .WithOne(t => t.BankAccount)
                .HasForeignKey(t => t.BankAccountId);

            // One-to-Many with Cards
            builder.HasMany(ba => ba.Cards)
                .WithOne(c => c.BankAccount)
                .HasForeignKey(c => c.BankAccountId);
        }
    }


}
