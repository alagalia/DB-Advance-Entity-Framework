

using System;
using System.Data.Entity.Validation;
using System.Linq;
using BankSystem.LogicLayer;
using BankSystem.Models;

namespace BankSystem
{
    class BankSystemStartUp
    {
        static void Main(string[] args)
        {
            BankContext context = new BankContext();
            //context.Database.Initialize(true);
            //context.Accounts.Add(new SavingAccount() {Number = 12345, Balance = 1200m, InterestRate = 20});
            //context.SaveChanges();
            //var a = context.Accounts.OfType<SavingAccount>().FirstOrDefault();
            string input = Console.ReadLine();
            CommandsRunner.ExecuteCommand(context, input);
            //var founded = context.Users.FirstOrDefault(u => u.UserName == "vlad123");
            //Console.WriteLine(founded);

        }
    }
}
