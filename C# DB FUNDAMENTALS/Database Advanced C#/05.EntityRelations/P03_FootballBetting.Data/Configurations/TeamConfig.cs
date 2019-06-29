using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    internal class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> team)
        {
            team.HasKey(k => k.TeamId);

            team.Property(e => e.Name)
                .IsRequired(true);

            team.Property(e => e.LogoUrl)
                .IsUnicode(false)
                .IsRequired(true);

            team.Property(e => e.Initials)
                .HasColumnType("NCHAR(3)")
                .IsRequired(true);

            team.HasOne(t => t.PrimaryKitColor)
                .WithMany(pk => pk.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            team.HasOne(t => t.SecondaryKitColor)
                .WithMany(pk => pk.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict); ;

            team.HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId);
        }
    }
}