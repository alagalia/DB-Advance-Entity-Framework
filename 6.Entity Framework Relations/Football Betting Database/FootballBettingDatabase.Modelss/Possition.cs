using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBettingDatabase.Models
{
    
    public class Possition
    {
        [Key]
        [StringLength(2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string Description { get; set; }

    }
}