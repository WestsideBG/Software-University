using BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.Configurations
{
    internal class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> bankAccount)
        {
            bankAccount.HasKey(b => b.BankAccountId);

            bankAccount.Property(b => b.Balance)
                .IsRequired();

            bankAccount.Property(b => b.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            bankAccount.Property(b => b.SwiftCode)
                .HasMaxLength(20)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}