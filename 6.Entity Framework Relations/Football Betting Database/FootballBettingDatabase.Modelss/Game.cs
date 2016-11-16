using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Game
    {
        public Game()
        {
            this.BetGames = new HashSet<BetGame>();
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        [Range(0, int.MaxValue)]
        public int HomeTeamGoals { get; set; }

        [Range(0, int.MaxValue)]
        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        [Range(0, int.MaxValue)]
        public float HomeTeamWinBetRate { get; set; }

        [Range(0, int.MaxValue)]
        public float AwayTeamWinBetRate { get; set; }

        [Range(0, int.MaxValue)]
        public float DrawGameBetRate { get; set; }

        public virtual Round Round { get; set; }

        public virtual Competition Competition { get; set; }


        public virtual ICollection<BetGame> BetGames { get; set; }


        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }


    }
}