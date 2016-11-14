using StudentSystem.Models;

namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }
        public virtual IDbSet<Resource> Resources { get; set; }
        public virtual IDbSet<Homework> Homeworks { get; set; }
        public virtual IDbSet<Course> Courses { get; set; }
        public virtual IDbSet<License> Licenses { get; set; }
        public virtual IDbSet<Picture> Pictures { get; set; }
        public virtual IDbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //many to manu self relations
            modelBuilder.Entity<Student>().HasMany(s => s.Students).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}