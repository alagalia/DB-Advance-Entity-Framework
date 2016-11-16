using System;
using System.Collections.Generic;

namespace FootballBettingDatabase.Models
{
    public class Bet
    {
        public Bet()
        {
            this.BetGames = new HashSet<BetGame>();
        }
        public int Id { get; set; }

        public decimal Money { get; set; }

        public DateTime DateTimeOfBet { get; set; }

        public virtual User User { get; set; }

        public ICollection<BetGame> BetGames { get; set; }

    }
}