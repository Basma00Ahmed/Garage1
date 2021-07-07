using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1.Vehicles
{
    public class Motorcycle: Vehicle
    {
        private int cylinderVolume;
        public int CylinderVolume { get => cylinderVolume; set => cylinderVolume = value; }
        public Motorcycle(string registrationNumber, string color, int numberOfWheels,int modelYear,int cylinderVolume) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            CylinderVolume=cylinderVolume;
        }
        public override string ToString()
        {
            return base.ToString() + $"CylinderVolume:{CylinderVolume}";
        }
        }
}
