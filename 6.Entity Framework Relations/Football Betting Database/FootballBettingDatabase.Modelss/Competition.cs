using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual CompetitionType CompetitionType { get; set; }
        //Type(local, national, international)

    }
}