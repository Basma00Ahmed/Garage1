using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1.Vehicles
{
    public class Boat : Vehicle
    {
        private double length;
        public double Length { get => length; set => length = value; }
        public Boat() { }
        public Boat(string registrationNumber, string color, int numberOfWheels,int modelYear, double length) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            Length= length;
        }

        public override string ToString()
        {
            return base.ToString() + $"Length:{Length}";
        }
        //public override IVehicle AddNewVehicle()
        //{
        //    _ = base.AddNewVehicle();
        //    SetLength();
        //    return this;
        //}
        void SetLength()
        {
            double length = 0;
            bool check_length;
            ui.Print("Enter Boat Length:");
            check_length = ui.ValidDouble(ui.GetInput(),out length);
            if (check_length)
                this.Length = length;
            else
                SetLength();
        }
    }
}
