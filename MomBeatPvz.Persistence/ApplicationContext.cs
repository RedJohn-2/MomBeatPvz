using Microsoft.EntityFrameworkCore;
using MomBeatPvz.Persistence.Configurations;
using MomBeatPvz.Persistence.Entities;
using MomBeatPvz.Persistence.Entities.Abstract;

namespace MomBeatPvz.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<HeroEntity> Heroes { get; set; }

        public DbSet<TierListEntity> TierLists { get; set; }

        public DbSet<TierListSolutionEntity> TierListSolutions { get; set; }

        public DbSet<HeroPriceEntity> HeroPrices { get; set; }

        public DbSet<ChampionshipEntity> Championships { get; set; }

        public DbSet<TeamEntity> Teams { get; set; }

        public DbSet<MatchEntity> Matches { get; set; }

        public DbSet<MatchResultEntity> MatchResults { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            /*Database.EnsureDeleted();*/
            Database.EnsureCreated();
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEntity
        {
            return Set<TEntity>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new HeroConfiguration());
            modelBuilder.ApplyConfiguration(new TierListConfiguration());
            modelBuilder.ApplyConfiguration(new TierListSolutionConfiguration());
            modelBuilder.ApplyConfiguration(new HeroPriceConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new MatchResultConfiguration());
            modelBuilder.ApplyConfiguration(new ChampionshipConfiguration());
        }
    }
}
