
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.ConsoleClient
{
    class StudentSystemMain
    {
        static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();
            //context.Database.Initialize(true);
            //------------------------------------
            //3.Working with the Database t.1
            //var students = context.Students;
            //foreach (Student student in students)
            //{
            //    Console.Write($"Student name: {student.Name} ");
            //    foreach (Homework homework in student.Homeworks)
            //    {
            //        Console.Write($"Homework content: {homework.Content}, homework contentType: {homework.ContentType}");
            //    }
            //    Console.WriteLine();
            //}

            //-------------------------
            //2.List all courses with their corresponding resources. Print the course name and description and everything for each resource. Order the courses by start date(ascending), then by end date(descending).

            //var courses = context.Courses.OrderBy(course => course.StartDate).ThenBy(course => course.EndtDate);
            //foreach (var course in courses)
            //{
            //    Console.WriteLine($"Course name: {course.Name}, description: {course.Description}, Students count: {course.Students.Count}, Start date:{course.StartDate}");
            //    foreach (Resource resource in course.Resources)
            //    {
            //        Console.WriteLine($"    Resource name:{resource.Name}, Type: {resource.TypeOfResource}, URL: {resource.Url}");
            //    }
            //}

            //--------------------
            //3.List all courses with more than 5 resources.Order them by resources count(descending), then by start date (descending).Print only the course name and the resource count.

            //------------------------
            //8.	Tag Attribute
            //string input = Console.ReadLine();
            //var tag = new Tag {Name = input};
            //context.Tags.Add(tag);
            //try
            //{
            //    context.SaveChanges();
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"{tag.Name} was added to database");
            //}
            //catch (Exception)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"{tag.Name} was NOT added to database");
            //}
            //Console.ForegroundColor = ConsoleColor.White ;

        }
    }
}
