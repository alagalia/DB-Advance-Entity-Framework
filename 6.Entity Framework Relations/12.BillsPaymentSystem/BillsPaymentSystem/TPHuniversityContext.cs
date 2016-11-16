using BillsPaymentSystem.Models;

namespace BillsPaymentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TPHuniversityContext : DbContext
    {
        public TPHuniversityContext()
            : base("name=TPHuniversityContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }
        
    }
}