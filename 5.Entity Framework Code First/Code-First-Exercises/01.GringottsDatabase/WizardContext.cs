using _01.GringottsDatabase.Models;

namespace _01.GringottsDatabase
{
    using System.Data.Entity;

    public class WizardContext : DbContext
    {
        public WizardContext()
            : base("name=WizardContext")
        {
        }

        public virtual DbSet<WizardDeposit> WizardDeposit { get; set; }
    }
    
}