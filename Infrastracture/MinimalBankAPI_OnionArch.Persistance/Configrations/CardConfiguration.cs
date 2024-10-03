using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MinimalBankAPI_OnionArch.Domain.Entities;

namespace MinimalBankAPI_OnionArch.Persistance.Configrations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(c => c.CVV)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(c => c.ExpirationDate)
                .IsRequired();

            // BankAccount ile ilişki
            builder.HasOne(c => c.BankAccount)
                .WithMany(ba => ba.Cards)
                .HasForeignKey(c => c.BankAccountId)
                .OnDelete(DeleteBehavior.Cascade); // veya istediğiniz silme davranışını ayarlayın

        
        }
    }



}
