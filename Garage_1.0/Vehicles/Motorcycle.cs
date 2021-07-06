using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    class Motorcycle: Vehicle
    {
        private int cylinderVolume;
        public int CylinderVolume { get => cylinderVolume; set => cylinderVolume = value; }
        public Motorcycle(string registrationNumber, string color, int numberOfWheels,int cylinderVolume) : base(registrationNumber, color, numberOfWheels)
        {
            CylinderVolume=cylinderVolume;
        }

     
    }
}
