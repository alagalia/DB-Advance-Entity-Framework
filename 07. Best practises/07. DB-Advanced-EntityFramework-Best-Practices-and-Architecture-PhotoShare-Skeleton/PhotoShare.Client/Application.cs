using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.IO;
using PhotoShare.Data.Intefaces;
using PhotoShare.Models;

namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Interfaces;
    using IO;

    class Application
    {
        static void Main()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();

            ICommandDispatcher commandDispatcher = new CommandDispatcher(unitOfWork);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IRunnable engine = new Engine(commandDispatcher, reader, writer);
            try
            {
                engine.Run("start");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult e in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError innerE in e.ValidationErrors)
                    {
                        Console.WriteLine(innerE.ErrorMessage);
                    }
                }
                throw;
            }


        }
    }
}
