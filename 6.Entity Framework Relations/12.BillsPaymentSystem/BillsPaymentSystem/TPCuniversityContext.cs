using System.ComponentModel.DataAnnotations.Schema;
using BillsPaymentSystem.Models;

namespace BillsPaymentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TPCuniversityContext : DbContext
    {
        public TPCuniversityContext()
            : base("name=TPCuniversityContext")
        {
        }

        public IDbSet<Person> Persons { get; set; }

        public IDbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(person => person.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Student>().Map(configuration =>
            {
                configuration.MapInheritedProperties();
                configuration.ToTable("Students");
            });

            modelBuilder.Entity<Teacher>().Map(configuration =>
            {
                configuration.MapInheritedProperties();
                configuration.ToTable("Teachers");
            }); base.OnModelCreating(modelBuilder);
        }
    }
}