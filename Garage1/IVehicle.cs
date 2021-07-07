using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1.Vehicles
{
    public interface IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get ; set ; }
        public int NumberOfWheels { get ; set; }
        public int ModelYear { get; set; }
        public Vehicle AddNewVehicle();

        public void SetRegistrationNumber();
        public void SetColor();
        public void SetNumberOfWheels();
        public void SetModelYear();
    }
}
