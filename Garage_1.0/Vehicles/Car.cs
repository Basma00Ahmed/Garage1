using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    class Car : Vehicle
    {
        private Fueltype fueltype;
        public Fueltype FuelType { get => fueltype; set => fueltype = value; }
        public Car(string registrationNumber, string color, int numberOfWheels,Fueltype fueltype) : base(registrationNumber, color, numberOfWheels)
        {
            FuelType = fueltype;
        }

        
    }
}
