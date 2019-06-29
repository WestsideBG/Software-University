namespace BillsPaymentSystem.Data.Configurations
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> paymentMethod)
        {
            paymentMethod.HasKey(p => p.Id);

            paymentMethod.HasOne(p => p.BankAccount)
                .WithOne(b => b.PaymentMethod);

            paymentMethod.HasOne(p => p.CreditCard)
                .WithOne(c => c.PaymentMethod);

            paymentMethod.HasOne(p => p.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(p => p.UserId);
        }
    }
}