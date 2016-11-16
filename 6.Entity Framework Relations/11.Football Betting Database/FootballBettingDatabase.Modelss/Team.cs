
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }

        [MaxLength(3)]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        [Required]
        public virtual Color PrimaryKitColor { get; set; }

        public virtual Color SecondKitColor { get; set; }

        [Required]
        public virtual Town Town { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}
