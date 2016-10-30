using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SetUpEntity
{
    class SetUpEntity
    {
        static void Main()
        {
            SoftuniContext context = new SoftuniContext();
            using (context)
            {
                #region 03 Employees full information
                //-----------3.	Employees full information

                //var employees = context.Employees;
                //employees.ToList().ForEach(
                //    e => Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}"));
                #endregion

                #region 04 Employees With Salary Over 50000

                ////---------4. Employees With Salary Over 50000
                //var emplNames = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName);

                //foreach (string emplName in emplNames)
                //{
                //    Console.WriteLine(emplName);
                //}
                #endregion

                #region 05 Employees from Seattle

                //var employees = context.Employees
                //    .Where(employee => employee.Department.Name == "Research and Development")
                //    .OrderBy(e => e.Salary)
                //    .ThenByDescending(e => e.FirstName);
                //foreach (var employee in employees)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
                //}
                #endregion

                #region 6.	Adding a New Address and Updating Employee
                //Address vitoshka = new Address { AddressText = "Vitoshka 15", TownID = 4 };
                //context.Addresses.Add(vitoshka);
                //Employee nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                //if (nakov != null)
                //{
                //    nakov.Address = vitoshka;
                //}
                //context.SaveChanges();

                //var top10Adresse =
                //    context.Employees.OrderByDescending(e => e.AddressID).Take(10).Select(e => e.Address.AddressText);
                //foreach (var adress in top10Adresse)
                //{
                //    Console.WriteLine(adress);
                //}
                #endregion

                #region 7.	Delete Project by Id
                //var wantedProject = context.Projects.Find(2);
                //wantedProject.Employees.Clear();
                //context.Projects.Remove(wantedProject);
                //context.SaveChanges();
                //var projectNames = context.Projects.Take(10).Select(p => p.Name);
                //foreach (var projectName in projectNames)
                //{
                //    Console.WriteLine(projectName);
                //}
                #endregion

                #region 8.Find employees in period

                //CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InstalledUICulture;
                //var wantedEmployees = context.Employees
                //    .Where(e => e.Projects.Count(proj => proj.StartDate.Year >= 2001 || proj.StartDate.Year <= 2003) > 0)
                //    .Take(30);
                //foreach (var employee in wantedEmployees)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");
                //    foreach (var project in employee.Projects)
                //    {
                //        Console.WriteLine($"--{project.Name} {project.StartDate} {project.EndDate}");
                //    }
                //}
                #endregion

                #region 9.	Addresses by town name 
                //var wantedAddresses =
                //    context.Addresses
                //    .OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Towns.Name)
                //    .Take(10);
                //foreach (var address in wantedAddresses)
                //{
                //    Console.WriteLine($"{address.AddressText}, {address.Towns.Name} - {address.Employees.Count} employees");
                //}
                #endregion
                #region 10.	Employee with id 147 sorted by project names 

                var wantedEmpl = context.Employees.FirstOrDefault(e => e.EmployeeID == 147);
                if (wantedEmpl != null)
                {
                    Console.WriteLine($"{wantedEmpl.FirstName} {wantedEmpl.LastName} {wantedEmpl.JobTitle}");
                    var projects = wantedEmpl.Projects.OrderBy(p => p.Name);

                    foreach (var project in projects)
                    {
                        Console.WriteLine($"{project.Name}");
                    }
                }

                #endregion

            }
        }
    }
}
