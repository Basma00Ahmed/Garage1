using System;

namespace Garage1.Vehicles
{
    public class Boat : Vehicle
    {
        private double length;
        public double Length { get => length; set => length = value; }
        public Boat() : base()
        {
            SetLength();
        }
        public Boat(string registrationNumber, string color, int numberOfWheels, int modelYear, double length) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            Length = length;
        }

        public override string ToString()
        {
            return base.ToString() + $"Length:{Length}";
        }

        void SetLength()
        {
            double length = 0;
            bool check_length;
            ui.Print("Enter Boat Length:");
            check_length = ui.ValidDouble(ui.GetInput(), out length);
            if (check_length)
                this.Length = length;
            else
                SetLength();
        }
        public override Type GetSubType()
        {
            return GetType();
        }
    }
}
