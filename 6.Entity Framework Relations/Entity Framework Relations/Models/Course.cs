using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Course
    {
        public Course(string name, DateTime startDate, DateTime endDate, decimal price )
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndtDate = endDate;
            this.Price = price;
            this.Students = new HashSet<Student>();
            this.Resources = new HashSet<Resource>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndtDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}