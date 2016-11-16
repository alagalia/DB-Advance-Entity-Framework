using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Competition
    {
        public Competition()
        {
            this.Games =  new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual CompetitionType CompetitionType { get; set; }
        //Type(local, national, international)

        public virtual ICollection<Game> Games { get; set; }

    }
}