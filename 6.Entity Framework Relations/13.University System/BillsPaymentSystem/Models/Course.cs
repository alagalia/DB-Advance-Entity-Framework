﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models
{
    public class Course
    {
        public Course()
        {
         this.Students = new HashSet<Student>();   
        }
        public int Id { get; set; }

        [Required]
        public string NameDiscription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual Teacher Teacher{ get; set; }
    }
}