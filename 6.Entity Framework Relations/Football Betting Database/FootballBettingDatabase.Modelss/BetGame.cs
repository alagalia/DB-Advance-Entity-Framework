using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBettingDatabase.Models
{
    public class BetGame
    {
        [Column(Order = 0), Key, ForeignKey("Bet")]
        public int BetId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Game")]
        public int GameId { get; set; }

        public Bet Bet { get; set; }

        public Game Game { get; set; }

        public virtual ResultPrediction ResultPrediction { get; set; }

         
    }
}