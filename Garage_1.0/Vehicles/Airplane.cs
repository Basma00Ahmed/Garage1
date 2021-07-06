using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    class Airplane : Vehicle
    {
        private int numberOfEngines;



        public int NumberOfEngines { get => numberOfEngines; set => numberOfEngines = value; }
        public Airplane(string registrationNumber, string color, int numberOfWheels, int numberOfEngines) : base(registrationNumber, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}
