using System;

namespace Garage1.Vehicles
{
    public class Car : Vehicle
    {
        private Fueltype fueltype;
        public Fueltype FuelType { get => fueltype; set => fueltype = value; }

        public Car() : base()
        {
            SetFuelType();
        }
        public Car(string registrationNumber, string color, int numberOfWheels, int modelYear, Fueltype fueltype) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            FuelType = fueltype;
        }

        public override string ToString()
        {
            return base.ToString() + $"Fuel type:{FuelType}";
        }

        void SetFuelType()
        {
            Fueltype fueltype = new Fueltype();

            ui.Print($"Select Car fuel type  by inputting the number (1, 2)"
                   + "\n1. Gasoline"
                   + "\n2. Diesel");
            string input = ""; //Creates the character input to be used with the switch-case below.
            try
            {
                input = ui.GetInput(); //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
            {
                Console.Clear();
                ui.ChangeConsoleColor("Please enter some number! \n", ConsoleColor.Red);
            }
            switch (input)
            {
                case "1":
                    fueltype = Fueltype.Gasoline;
                    break;
                case "2":
                    fueltype = Fueltype.Diesel;
                    break;
                default:
                    ui.ChangeConsoleColor("Please enter some valid number (1, 2)\n", ConsoleColor.Red);
                    SetFuelType();
                    break;
            }
            this.FuelType = fueltype;

        }
        public override Type GetSubType()
        {
            return GetType();
        }
    }
}
