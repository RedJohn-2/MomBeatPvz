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
    public class MatchConfiguration : IEntityTypeConfiguration<MatchEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .HasOne(m => m.Championship)
                .WithMany(c => c.Matches);

            builder
                .HasMany(m => m.Results)
                .WithOne(r => r.Match);

            builder.ToTable(nameof(Match));
        }
    }
}
