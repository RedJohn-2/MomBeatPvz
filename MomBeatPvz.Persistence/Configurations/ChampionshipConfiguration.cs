using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Persistence.Configurations
{
    public class ChampionshipConfiguration : IEntityTypeConfiguration<ChampionshipEntity>
    {
        public void Configure(EntityTypeBuilder<ChampionshipEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(30);

            builder
                .HasMany(c => c.Teams)
                .WithOne(t => t.Championship);

            builder
                .HasMany(c => c.Matches)
                .WithOne(m => m.Championship);

            builder
                .HasMany(c => c.Heroes)
                .WithMany();

            builder
                .HasOne(c => c.Creator)
                .WithMany();

            builder
                .HasOne(c => c.TierList)
                .WithOne(t => t.Championship)
                .HasForeignKey<ChampionshipEntity>(c => c.TierListId);

            builder.ToTable(nameof(Championship));
        }
    }
}
