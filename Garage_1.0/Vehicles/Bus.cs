using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    class Bus : Vehicle
    {
        private int numberOfSeats;
        public int NumberOfSeats { get => numberOfSeats; set => numberOfSeats = value; }
        public Bus(string registrationNumber, string color, int numberOfWheels,int numberOfSeats) : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfSeats= numberOfSeats;
        }

       
    }
}
