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
    public class HeroPriceConfiguration : IEntityTypeConfiguration<HeroPriceEntity>
    {
        public void Configure(EntityTypeBuilder<HeroPriceEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.Hero)
                .WithMany();

            builder.
                HasOne(p => p.Solution)
                .WithMany(s => s.HeroPrices);

            builder.ToTable(nameof(HeroPrice));
        }
    }
}
