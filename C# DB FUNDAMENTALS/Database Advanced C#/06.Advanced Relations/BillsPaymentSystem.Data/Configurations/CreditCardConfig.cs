using BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.Configurations
{
    internal class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> creditCard)
        {
            creditCard.HasKey(c => c.CreditCardId);

            creditCard.Property(c => c.Limit)
                .IsRequired();

            creditCard.Property(c => c.MoneyOwed)
                .IsRequired();
        }
    }
}