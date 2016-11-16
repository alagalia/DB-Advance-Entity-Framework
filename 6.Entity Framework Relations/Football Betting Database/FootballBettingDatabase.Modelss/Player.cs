using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Player
    {
        public Player()
        {
            this.Games = new HashSet<Game>();
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        public bool IsInjured { get; set; }

        public virtual Team Team { get; set; }

        public virtual Possition Possition { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}