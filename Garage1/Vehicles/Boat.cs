using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1.Vehicles
{
    public class Boat : Vehicle
    {
        private double length;
        public double Length { get => length; set => length = value; }
        public Boat(string registrationNumber, string color, int numberOfWheels,int modelYear, double length) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            Length= length;
        }

        public override string ToString()
        {
            return base.ToString() + $"Length:{Length}";
        }
    }
}
