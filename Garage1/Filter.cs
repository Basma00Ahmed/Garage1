using System;
using System.Collections.Generic;
using System.Text;
using Garage1.Vehicles;
namespace Garage1
{
    public class  Filter
    {
        public string registrationNumber = null;
        public string color = null;
        public int numberOfWheels  = 0;
        public int modelYear  = 0;
        public int numberOfEngines  = 0;
        public double length  = 0;
        public int numberOfSeats  = 0;
        public Fueltype fueltype  = new Fueltype();
        public int cylinderVolume = 0;
        public string type = null;
    }
}
