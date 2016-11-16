using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBettingDatabase.Models
{
    
    public class Possition
    {
        public Possition()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        [MaxLength(2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}