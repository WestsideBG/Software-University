using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> bet)
        {
            bet.HasKey(b => b.BetId);


            bet.Property(e => e.Prediction)
                .IsRequired(true);

            bet.Property(e => e.DateTime)
                .HasDefaultValue(DateTime.Now);

            bet.Property(e => e.UserId)
                .IsRequired(true);

            bet.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

            bet.HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
        }
    }
}