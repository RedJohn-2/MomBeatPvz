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
    public class TierListConfiguration : IEntityTypeConfiguration<TierListEntity>
    {
        public void Configure(EntityTypeBuilder<TierListEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.
                HasMany(t => t.Solutions)
                .WithOne(s => s.TierList);

            builder.
                HasOne(t => t.Creator)
                .WithMany();

            builder
                .HasOne(t => t.Championship)
                .WithOne(c => c.TierList)
                .HasForeignKey<ChampionshipEntity>(c => c.Id);

            builder.Property(t => t.Name).HasMaxLength(80);

            builder.ToTable(nameof(TierList));
        }
    }
}
