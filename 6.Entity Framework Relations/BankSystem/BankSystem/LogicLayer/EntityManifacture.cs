using System.Collections.Generic;
using BankSystem.Models;

namespace BankSystem.LogicLayer
{
    public class EntityManifacture
    {
        public static User CreateUser(List<string> commands)
        {
            User user = new User(commands[1],commands[2],commands[3]);
            return user;
        }

        public static SavingAccount CreateSavingAccount(List<string> commands)
        {
            SavingAccount savingAccount = new SavingAccount();
            return savingAccount;
        }
    }
}