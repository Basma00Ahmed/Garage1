using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Garage1.Vehicles
{

    public abstract class Vehicle : IVehicle
    {
        internal IUI ui = new ConsoleUI();

        private string registrationNumber;
        private string color;
        private int numberOfWheels;
        private int modelYear;
        public Regex regex = new Regex(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}");
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value;}
        public string Color { get => color; set => color = value; }
        public int NumberOfWheels { get => numberOfWheels; set => numberOfWheels = value; }
        public int ModelYear { get => modelYear; set => modelYear = value; }

        public Vehicle(string registrationNumber, string color, int numberOfWheels,int modelYear)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
            ModelYear = modelYear;
        }
        public Vehicle()
        {
            SetRegistrationNumber();

            SetColor();

            SetNumberOfWheels();

            SetModelYear();
        }
        public override string ToString()
        {
            return $"Registration Number: {RegistrationNumber}  Color: {Color}  Number Of Wheels:{NumberOfWheels}  Model Year:{ModelYear}  ";
        }


        public void SetRegistrationNumber( )
        {
            bool check_registrationNumber, check_format;
            string registrationNumber;
            ui.Print("Enter The Registration Number Ex.'ABC123':");
            registrationNumber = ui.GetInput();
            check_registrationNumber = ui.ValidString(registrationNumber);
            check_format =Regex.IsMatch(registrationNumber, @"^[A-Z]{3}[0-9]{3}$");
            if (check_registrationNumber&& check_format)
                this.RegistrationNumber = registrationNumber;
            else
            {
                ui.ChangeConsoleColor("Invalid Vehicle Identification Number Format.", ConsoleColor.Red);
               SetRegistrationNumber();
            }
        }

        public void SetColor()
        {
            string color;
            bool check_color;
            ui.Print("Enter The Color:");
            color = ui.GetInput();
            check_color = ui.ValidString(color);
            if (check_color)
                this.Color = color;
            else
                SetColor();
        }

        public void SetNumberOfWheels()
        {
            int numberOfWheels = 0;
            bool check_numberOfWheels;
            ui.Print("Enter The Number Of Wheels:");
            check_numberOfWheels = ui.ValidInt(ui.GetInput(),out numberOfWheels);
            if (check_numberOfWheels)
                this.NumberOfWheels = numberOfWheels;
            else
                SetNumberOfWheels();
        }
        public void SetModelYear()
        {
            int modelYear = 0;
            bool check_modelYear;
            ui.Print("Enter The Model Year:");
            check_modelYear = ui.ValidInt(ui.GetInput(),out modelYear);
            if (check_modelYear)
                this.ModelYear = modelYear;
            else
                SetModelYear();
        }
        public abstract Type GetSubType();
    }
}
