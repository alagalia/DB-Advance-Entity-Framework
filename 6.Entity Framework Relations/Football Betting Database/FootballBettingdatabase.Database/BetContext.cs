using System.ComponentModel.DataAnnotations.Schema;
using FootballBettingDatabase.Models;

namespace FootballBettingdatabase.Database
{
    using System.Data.Entity;

    public class BetContext : DbContext
    {
        public BetContext()
            : base("name=BetContext")
        {
        }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Possition> Possitions { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }
        public virtual DbSet<BetGame> BetGames { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<ResultPrediction> ResultPredictions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //many to many
            //modelBuilder.Entity<Country>()
            //    .HasMany<Continent>(country => country.Continent)
            //    .WithMany(continent => continent.Countries)
            //    .Map(configuration =>
            //    {
            //        configuration.MapLeftKey("CountryId");
            //        configuration.MapRightKey("ContinentId");
            //        configuration.ToTable("CountryContinents");
            //    });
            base.OnModelCreating(modelBuilder);

        }
    }
}