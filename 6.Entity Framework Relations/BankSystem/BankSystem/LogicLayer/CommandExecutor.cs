using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using BankSystem.Models;

namespace BankSystem.LogicLayer
{

    public class CommandExecutor
    {
        private static bool loggedUser;
        
        public static void ExecuteRegisterCommand(BankContext context, List<string> commands)
        {
            User user = EntityManifacture.CreateUser(commands);
            User founded = context.Users.First(u => u.UserName == user.UserName);
            if (founded != null)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public static void ExecuteLoginCommand(BankContext context, List<string> commands)
        {
            string userName = commands[1];
            var founded = context.Users.FirstOrDefault(u => u.UserName == userName);
            if (founded == null || founded.Password != commands[2])
            {
                throw new VerificationException("Incorrect username / password");
            };

            loggedUser = true;
            founded.IsLoggedIn = true;
        }

        public static void ExecuteLogoutCommand(List<string> commands)
        {
            if (loggedUser == false)
            {
                throw new VerificationException("Cannot log out. No user was logged in.");
            };
        }

        public static void ExecuteAddSavingAccountCommand(List<string> commands)
        {

        }

        public static void ExecuteAddCheckingAccountCommand(List<string> commands)
        {

        }

        public static void ExecuteListAccountsCommand(List<string> commands)
        {

        }

        public static void ExecuteDepositCommand(List<string> commands)
        {

        }

        public static void ExecuteWithdrawCommand(List<string> commands)
        {

        }

        public static void ExecuteDeductFeeCommand(List<string> commands)
        {

        }

        public static void ExecuteAddInterestCommand(List<string> commands)
        {

        }
    }
}