
using System;
using System.Linq;
using VehicleSystem.Models.MotorVehicle;

namespace VehicleSystem
{
    class VehicleMain
    {
        static void Main()
        {
            VehicleContext context = new VehicleContext();
            //context.Database.Initialize(true);

            //CruiseShip ship = new CruiseShip()
            //{
            //    Nationality = "Germany",
            //    PassengersCapacity = 120,
            //    CapitanName = "Irina",
            //    EngineType = "TAKO",
            //    NumberOfEngines = 10,
            //    Manufacturer = "MEI",
            //    MaxSpeed =6,
            //    Model = "Disel",
            //    Price = 54300
            //};
            //context.MyEntities.Add(ship);
            //context.SaveChanges();

            //var cargo = context.MyEntities.OfType<CruiseShip>().FirstOrDefault();

            //Console.WriteLine($"ID: {cargo.Id}, Capitan name: {cargo.CapitanName}, Nationality {cargo.Nationality}, SizeOfCrew {cargo.SizeOfCrew}");
        }
    }
}
