namespace _01.GringottsDatabase
{
    using System;
    using Models;
    class WizardMain
    {
        static void Main()
        {
            WizardDeposit dumbledore = new WizardDeposit()
            {
                FirstName = "Albus",
                LastName = "dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2,
                IsDepositExpired = false
            };

            var context = new WizardContext();
            context.WizardDeposit.Add(dumbledore);
            context.SaveChanges();
        }
    }
}
