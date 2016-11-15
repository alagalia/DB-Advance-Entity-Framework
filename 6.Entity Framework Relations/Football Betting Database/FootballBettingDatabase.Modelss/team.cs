
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBettingDatabase.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Logo { get; set; }

        [StringLength(3)]
        public string Initials { get; set; }

        public virtual Color PrimaryKitColor { get; set; }

        public virtual Color SecondKitColor { get; set; }

        public virtual Town Town { get; set; }

        public decimal Budget { get; set; } 
    }
}
