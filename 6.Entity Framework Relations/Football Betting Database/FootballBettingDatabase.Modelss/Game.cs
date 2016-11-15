using System;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public float HomeTeamWinBetRate { get; set; }
        public float AwayTeamWinBetRate { get; set; }
        public float DrawGameBetRate { get; set; }
        public virtual Round Round { get; set; }
        public virtual Competition Competition { get; set; }
    }
}