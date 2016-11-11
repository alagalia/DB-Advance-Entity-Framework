using _04.SalesDatabase.Models;

namespace _04.SalesDatabase
{
    using System.Data.Entity;

    public class SalesContext : DbContext
    {
        
        public SalesContext()
            : base("name=SalesContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<SalesContext>());
            //this.Database.Initialize(true);
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
    }
}