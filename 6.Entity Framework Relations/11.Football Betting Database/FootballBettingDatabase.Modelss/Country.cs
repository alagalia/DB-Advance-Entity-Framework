using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Country
    {
        public Country()
        {
            this.Continents = new HashSet<Continent>();
            this.Towns = new HashSet<Town>();
        }

        [Key]
        [StringLength(3)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Continent> Continents { get; set; }

        public virtual ICollection<Town> Towns { get; set; }

    }
}