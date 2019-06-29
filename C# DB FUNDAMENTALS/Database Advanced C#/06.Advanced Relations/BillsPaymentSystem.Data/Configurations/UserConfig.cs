using BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.UserId);

            user.Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            user.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            user.Property(u => u.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            user.Property(u => u.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}