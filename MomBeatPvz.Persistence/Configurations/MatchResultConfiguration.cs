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
    public class MatchResultConfiguration : IEntityTypeConfiguration<MatchResultEntity>
    {
        public void Configure(EntityTypeBuilder<MatchResultEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder
                .HasOne(r => r.Match)
                .WithMany(m => m.Results);

            builder
                .HasOne(r => r.Team)
                .WithMany();

            builder.ToTable(nameof(MatchResult));
        }
    }
}
