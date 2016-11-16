using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            //Student st= new Student() {Name = "Ivan4o", Registrationdate = DateTime.Now, BirthDay = DateTime.Now, PhoneNumber = "2w4421"};
            //Student st1 = new Student() { Name = "Petyr", Registrationdate = DateTime.Now, BirthDay = DateTime.Now, PhoneNumber = "5509843" };
            //Student st2 = new Student() { Name = "Nina", Registrationdate = DateTime.Now, BirthDay = DateTime.Now, PhoneNumber = "00033300" };

            ////create courses
            //Course c1 = new Course() {Name = "Math", Description = "Match many", Price = 200, StartDate = DateTime.Now, EndtDate = DateTime.Now};
            //c1.Students.Add(st);
            //c1.Students.Add(st1);

            //Course c2 = new Course() { Name = "History", Description = "History many", Price = 120, StartDate = DateTime.Now, EndtDate = DateTime.Now };
            //c1.Students.Add(st1);
            //c1.Students.Add(st2);

            ////create homeworks
            //Homework hm = new Homework() {Content = "Home", Course = c2, Student = st1, SubmissionDate = DateTime.Now, ContentType = "pdf"};

            //Homework hm1 = new Homework() { Content = "For Math", Course = c1, Student = st, SubmissionDate = DateTime.Now, ContentType = "pdf" };

            //Homework hm2 = new Homework() { Content = "For Math again", Course = c1, Student = st2, SubmissionDate = DateTime.Now, ContentType = "pdf" };

            ////create resources
            //Resource rs = new Resource() {Name = "For Math res", Course = c1, Url = "www.some.com", TypeOfResource = "presentation"};

            //Resource rs1 = new Resource() { Name = "For History res", Course = c1, Url = "www.opa.com", TypeOfResource = "presentation" };

            //context.Homeworks.Add(hm);
            //context.Homeworks.Add(hm1);
            //context.Homeworks.Add(hm2);
            //context.Resources.Add(rs);
            //context.Resources.Add(rs1);

            //add tag with vallidaTOR
            //Tag tg = new Tag {Name = "#ABigFunnyBirthDay1234567890abcdef"};
            //context.Tags.Add(tg);

        }
    }
}