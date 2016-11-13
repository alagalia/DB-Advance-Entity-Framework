using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required, RegularExpression("application|pdf|zip")]
        public string ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}