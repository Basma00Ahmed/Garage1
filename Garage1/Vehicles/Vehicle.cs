using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1.Vehicles
{ 
    
    public abstract class Vehicle : IVehicle
    {
        internal IUI ui = new ConsoleUI();

        private string registrationNumber;
        private string color;
        private int numberOfWheels;
        private int modelYear;
     
        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
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
        public override string ToString()
        {
            return $"Registration Number: {RegistrationNumber}  Color: {Color}  Number Of Wheels:{NumberOfWheels}  Model Year:{ModelYear}  ";
        }

        public virtual Vehicle AddNewVehicle()
        {
            SetRegistrationNumber();
           
            SetColor();
      
            SetNumberOfWheels();
         
            SetModelYear();
            return this;

        }

        public void SetRegistrationNumber( )
        {
            bool check_registrationNumber;
            string registrationNumber;
            ui.Print("Enter Registration Number of car:");
            registrationNumber = ui.GetInput();
            check_registrationNumber = ui.ValidString(registrationNumber);
            if (check_registrationNumber)
                this.RegistrationNumber = registrationNumber;
            else
               SetRegistrationNumber();
        }

        public void SetColor()
        {
            string color;
            bool check_color;
            ui.Print("Enter Color of car:");
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
            ui.Print("Enter Color of car:");
            check_numberOfWheels = ui.ValidInt(ui.GetInput(), numberOfWheels);
            if (check_numberOfWheels)
                this.NumberOfWheels = numberOfWheels;
            else
                SetNumberOfWheels();
        }

        public void SetModelYear()
        {
            int modelYear = 0;
            bool check_modelYear;
            ui.Print("Enter Color of car:");
            check_modelYear = ui.ValidInt(ui.GetInput(), modelYear);
            if (check_modelYear)
                this.ModelYear = modelYear;
            else
                SetModelYear();
        }

    }
}
