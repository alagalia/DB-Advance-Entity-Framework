using BillsPaymentSystem.Models;

namespace BillsPaymentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TpTuniversityContext : DbContext
    {
        
        public TpTuniversityContext()
            : base("name=TPTuniversityContext")
        {
        }
        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            base.OnModelCreating(modelBuilder);
        }
    }

}