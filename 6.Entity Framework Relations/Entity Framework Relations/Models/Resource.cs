using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, RegularExpression("video|presentation|document|other")]
        public string TypeOfResource { get; set; }

        [Required]
        public string Url { get; set; }

        //public virtual int CourseId { get; set; }

        //[ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}