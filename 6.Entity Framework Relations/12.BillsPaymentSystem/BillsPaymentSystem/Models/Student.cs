using System.Collections.Generic;

namespace BillsPaymentSystem.Models
{
    public class Student :Person
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public double AverageGrade { get; set; }

        public string Attendance { get; set; }

        public virtual ICollection<Course> Courses  { get; set; }
    }
}