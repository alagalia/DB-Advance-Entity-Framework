namespace BankSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankSystem.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BankSystem.BankContext";
        }

        protected override void Seed(BankSystem.BankContext context)
        {
        }
    }
}
