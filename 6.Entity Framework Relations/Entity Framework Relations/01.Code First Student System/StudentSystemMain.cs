
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
            context.Database.Initialize(true);

        }
    }
}
