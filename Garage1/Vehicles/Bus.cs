using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1.Vehicles
{
    public class Bus : Vehicle
    {
        private int numberOfSeats;
        public int NumberOfSeats { get => numberOfSeats; set => numberOfSeats = value; }
        public Bus(string registrationNumber, string color, int numberOfWheels,int modelYear,int numberOfSeats) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            NumberOfSeats= numberOfSeats;
        }

        public override string ToString()
        {
            return base.ToString() + $"Number Of Seats:{NumberOfSeats}";
        }
    }
}
