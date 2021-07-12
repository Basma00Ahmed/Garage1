using System;

namespace Garage1.Vehicles
{
    public class Bus : Vehicle
    {
        private int numberOfSeats;
        public int NumberOfSeats { get => numberOfSeats; set => numberOfSeats = value; }
        public Bus() : base()
        {
            SetNumberOfSeats();
        }
        public Bus(string registrationNumber, string color, int numberOfWheels, int modelYear, int numberOfSeats) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return base.ToString() + $"Number Of Seats:{NumberOfSeats}";
        }

        void SetNumberOfSeats()
        {
            int numberOfSeats = 0;
            bool check_numberOfSeats;
            ui.Print("Enter Number Of Seats:");
            check_numberOfSeats = ui.ValidInt(ui.GetInput(), out numberOfSeats);
            if (check_numberOfSeats)
                this.NumberOfSeats = numberOfSeats;
            else
                SetNumberOfSeats();
        }
        public override Type GetSubType()
        {
            return GetType();
        }
    }
}
