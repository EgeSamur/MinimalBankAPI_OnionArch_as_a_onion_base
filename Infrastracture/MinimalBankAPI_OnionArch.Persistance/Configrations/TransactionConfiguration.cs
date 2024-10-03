using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transactionn>
    {
        public void Configure(EntityTypeBuilder<Transactionn> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Amount)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(t => t.TransactionDate)
                .IsRequired();

            builder.Property(t => t.TransactionType)
                .IsRequired();

            // Foreign key for BankAccount
            builder.HasOne(t => t.BankAccount)
                .WithMany(ba => ba.Transactions)
                .HasForeignKey(t => t.BankAccountId);
        }
    }


}
