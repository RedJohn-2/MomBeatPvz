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
    public class TierListSolutionConfiguration : IEntityTypeConfiguration<TierListSolutionEntity>
    {
        public void Configure(EntityTypeBuilder<TierListSolutionEntity> builder)
        {
            builder.HasKey(s => s.Id);

            /*builder.HasAlternateKey(s => new { s.OwnerId, s.TierListId });*/

            builder.
                HasOne(s => s.Owner)
                .WithMany();

            builder.
                HasMany(s => s.HeroPrices)
                .WithOne(p => p.Solution);

            builder.ToTable(nameof(TierListSolution));
        }
    }
}
