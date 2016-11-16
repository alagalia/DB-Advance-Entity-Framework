namespace FootballBettingData
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using FootballBettingModels;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
            : base("name=FootballBettingContext")
        {
        }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Possitions { get; set; }
        public virtual DbSet<PlayerStatistics> PlayerStatistics { get; set; }
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
            modelBuilder.Entity<Country>()
                .HasMany<Continent>(country => country.Continent)
                .WithMany(continent => continent.Countries)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("CountryId");
                    configuration.MapRightKey("ContinentId");
                    configuration.ToTable("CountryContinents");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}