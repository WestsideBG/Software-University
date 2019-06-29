using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.UserId);

            user.HasKey(e => e.UserId);

            user.Property(e => e.Username)
                .IsUnicode(true)
                .IsRequired(true);

            user.Property(e => e.Password)
                .IsUnicode(false)
                .IsRequired(true);

            user.Property(e => e.Email)
                .IsUnicode(false)
                .IsRequired(true);

            user.Property(e => e.Name)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}