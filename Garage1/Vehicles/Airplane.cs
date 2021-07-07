using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1.Vehicles
{
    public class Airplane : Vehicle
    {
        private int numberOfEngines;
        public int NumberOfEngines { get => numberOfEngines; set => numberOfEngines = value; }
        public Airplane(string registrationNumber, string color, int numberOfWheels,int modelYear, int numberOfEngines) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            NumberOfEngines = numberOfEngines;
        }
        public override string ToString()
        {
            return base.ToString() + $"Number Of Engines:{NumberOfEngines}";
        }
       
    }
}
