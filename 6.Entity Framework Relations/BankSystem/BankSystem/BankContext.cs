using BankSystem.Models;

namespace BankSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankContext : DbContext
    {
        public BankContext()
            : base("name=BankContext")
        {
        }

       public virtual DbSet<Account> Accounts { get; set; }
       public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckingAccount>().ToTable("CheckingAccounts");
            modelBuilder.Entity<SavingAccount>().ToTable("SavingAccounts");
            base.OnModelCreating(modelBuilder);
        }
    }
    
}