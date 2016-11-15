using System;

namespace FootballBettingDatabase.Models
{
    public class Bet
    {
        public int Id { get; set; }

        public decimal Money { get; set; }

        public DateTime DateTimeOfBet { get; set; }

        public User User { get; set; }
    }
}