using System.Collections.Generic;
using VehicleSystem.Models.Carriages;

namespace VehicleSystem.Models.MotorVehicle
{
    public class Train :MotorVehicle
    {
        public Locomotive Locomotive { get; set; }

        public int NumberOfCarriages { get; set; }

        public virtual ICollection<Carriage> Carriageses { get; set; }  
    }
}