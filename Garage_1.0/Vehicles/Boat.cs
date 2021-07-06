using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    class Boat : Vehicle
    {
        private float length;
        public float Length { get => length; set => length = value; }
        public Boat(string registrationNumber, string color, int numberOfWheels,float length) : base(registrationNumber, color, numberOfWheels)
        {
            Length= length;
        }

       
    }
}
