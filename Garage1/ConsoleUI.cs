using System;
using System.Collections.Generic;
using System.Text;
using Garage1.Vehicles;

namespace Garage1
{
    public class ConsoleUI : IUI
    {
        public ConsoleColor Color { get; set; }
        public string GetInput()
        {
            return Console.ReadLine();
        }
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public void Print(Vehicle vehicle)
        {
            Console.WriteLine(vehicle.ToString());
        }
        public void ChangeConsoleColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Print(message);
            Console.ResetColor();
        }
        public void InstallNewGarage()
        {
            string name;
            int capacity=0;
            bool intCheck;
            Print("Enter Garage Name : ");
            name = GetInput();
            Print("Enter Garage Capacity : ");
            intCheck = ValidInt(GetInput(),capacity);
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity, name);
            ChangeConsoleColor($"Successfully installed {name} garage\n", ConsoleColor.Green);
            DisplayGarageSubMenu(garage);
        }
        public void DisplayGarageSubMenu(Garage<Vehicle> garage)
        {
            while (true)
            {
                Print($"Please navigate through the {garage.Name } Garage menu by inputting the number \n(1, 2, 3, 4, 5, 6, 0) of your choice"
                    + "\n1. Park new vehicle"
                    + "\n2. Pick up vehicle"
                    + "\n3. List all parked vehicles"
                    + "\n4. List vehicle types"
                    + "\n5. Find vehicle by registration number"
                    + "\n6. Search for vehicles"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = GetInput()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                {
                    Console.Clear();
                    ChangeConsoleColor("Please enter some input! \n", ConsoleColor.Red);
                }
                switch (input)
                {
                    case '1':
                        DisplayAddVehicleSubMenu(garage);
                        break;
                    case '2':

                        break;
                    case '3':

                        break;
                    case '4':

                        break;
                    case '5':

                        break;
                    case '6':

                        break;

                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        ChangeConsoleColor("Please enter some valid input (0, 1, 2, 3, 4, 5, 6)\n", ConsoleColor.Red);
                        break;
                }
            }
        }
        public void DisplayAddVehicleSubMenu(Garage<Vehicle> garage)
        {
            while (true)
            {
                Print($"For Park new vehicle in the {garage.Name} Garage Select  type of vehicle by inputting the number \n(1, 2, 3, 4, 5, 0) of your choice"
                    + "\n1. Airplane"
                    + "\n2. Boat"
                    + "\n3. Bus"
                    + "\n4. Car"
                    + "\n5. Motorcycle"
                    + "\n0. Exit to Previous menu");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = GetInput()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                {
                    Console.Clear();
                    ChangeConsoleColor("Please enter some input! \n", ConsoleColor.Red);
                }
                switch (input)
                {
                    case '1':
                        ChangeConsoleColor("-------Airplane Information-------", ConsoleColor.Cyan);
                       
                        break;
                    case '2':
                        ChangeConsoleColor("-------Boat Information-------", ConsoleColor.Cyan);
                        break;
                    case '3':
                        ChangeConsoleColor("-------Bus Information-------", ConsoleColor.Cyan);
                        break;
                    case '4':
                        ChangeConsoleColor("-------Car Information-------", ConsoleColor.Cyan);
                        break;
                    case '5':
                        ChangeConsoleColor("-------Motorcycle Information-------", ConsoleColor.Cyan);
                        break;
                    case '0':
                        DisplayGarageSubMenu(garage);
                        break;
                    default:
                        ChangeConsoleColor("Please enter some valid input (0, 1, 2, 3, 4, 5)\n", ConsoleColor.Red);
                        break;
                }
            }
        }

        public bool ValidString(string message)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
            {
                ChangeConsoleColor("Please enter some valid input! \n", ConsoleColor.Red);
                return false; 
            }
            else return true;
        }

        public bool ValidInt(string message,int number)
        {
            if (int.TryParse(message, out number )== false)
            {
                ChangeConsoleColor("Please enter some valid number! \n", ConsoleColor.Red);
                return false;
            }
            else
                return true;
        }

        public bool ValidDouble(string message, double number)
        {
            if (double.TryParse(message, out number) == false)
            {
                ChangeConsoleColor("Please enter some valid number! \n", ConsoleColor.Red);
                return false;
            }
            else
                return true;
                   
        }
    }
}
