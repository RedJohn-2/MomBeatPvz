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
    public class TeamConfiguration : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(30);

            builder
                .HasOne(t => t.Author)
                .WithMany();

            builder
                .HasOne(t => t.Championship)
                .WithMany(c => c.Teams);

            builder
                .HasMany(t => t.Heroes)
                .WithMany();

            builder.ToTable(nameof(Team));
        }
    }
}
