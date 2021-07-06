using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0
{
    public abstract class Vehicle : IVehicle
    {
        private string registrationNumber;
        private string color;
        private int numberOfWheels;

        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public string Color { get => color; set => color = value; }
        public int NumberOfWheels { get => numberOfWheels; set => numberOfWheels = value; }
        public Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }
    }
}
