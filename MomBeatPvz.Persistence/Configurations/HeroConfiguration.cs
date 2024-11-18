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
    public class HeroConfiguration : IEntityTypeConfiguration<HeroEntity>
    {
        public void Configure(EntityTypeBuilder<HeroEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name).HasMaxLength(30);

            builder.ToTable(nameof(Hero));
        }
    }
}
