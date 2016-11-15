using System.ComponentModel.DataAnnotations;

namespace FootballBettingDatabase.Models
{
    public class CompetitionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}