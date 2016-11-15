using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBettingDatabase.Models
{
    public class PlayerStatistic
    {
        [Column(Order = 0), Key, ForeignKey("Game")]
        public int GameId { get; set; }

        [Column(Order = 1), Key, ForeignKey("Player")]
        public int PlayerId { get; set; }

        public virtual Game Game { get; set; }

        public virtual Player Player { get; set; }

        public int ScoredGoal { get; set; }

        public int PlayerAssist { get; set; }

        public int PlayedMinitesDuringGame { get; set; }

    }
}