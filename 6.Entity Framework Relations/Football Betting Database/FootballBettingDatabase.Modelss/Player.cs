using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public virtual Team Team { get; set; }

        public virtual Possition Possition { get; set; }

        public bool IsInjured { get; set; }

    }
}