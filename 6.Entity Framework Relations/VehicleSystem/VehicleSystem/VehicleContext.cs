using VehicleSystem.Models;
using VehicleSystem.Models.Carriages;
using VehicleSystem.Models.MotorVehicle;
using VehicleSystem.Models.NonMotorVehicle;

namespace VehicleSystem
{
    using System.Data.Entity;

    public class VehicleContext : DbContext
    {
        public VehicleContext()
            : base("name=VehicleContext")
        {
        }

       public virtual DbSet<Vehicle> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PassengerCarriage>().ToTable("PassengerCarriages");
            modelBuilder.Entity<RestaurantCarriage>().ToTable("RestaurantCarriages");
            modelBuilder.Entity<SleepingCarriage>().ToTable("SleepingCarriages");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<CargoShip>().ToTable("CargoShips");
            modelBuilder.Entity<CruiseShip>().ToTable("CruiseShips");
            modelBuilder.Entity<Plane>().ToTable("Planes");
            modelBuilder.Entity<Train>().ToTable("Trains");
            modelBuilder.Entity<Bike>().ToTable("Bike");
            modelBuilder.Entity<Locomotive>().ToTable("Locomotives");

            modelBuilder.Entity<Train>()
                .HasRequired(t => t.Locomotive)
                .WithRequiredPrincipal(l => l.Train);
            base.OnModelCreating(modelBuilder);
        }
    }

    
}