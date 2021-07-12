using Garage1.Vehicles;
using System;
using System.Collections.Generic;

namespace Garage1
{
    public class ConsoleUI : IUI
    {
        
        public Filter filter = new Filter();
        
        public string GetInput()
        {
            return Console.ReadLine();
        }
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public void ChangeConsoleColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Print(message);
            Console.ResetColor();
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
        public bool ValidInt(string message, out int number)
        {
            if (int.TryParse(message, out number) == false)
            {
                ChangeConsoleColor("Please enter some valid number! \n", ConsoleColor.Red);
                return false;
            }
            else
                return true;
        }
        public bool ValidDouble(string message, out double number)
        {
            if (double.TryParse(message, out number) == false)
            {
                ChangeConsoleColor("Please enter some valid number! \n", ConsoleColor.Red);
                return false;
            }
            else
                return true;
        }
        #region Display Menu
        public void DisplayGarageSubMenu(GarageHandler garage)
        {
            while (true)
            {
                ChangeConsoleColor($"---------Garage {garage.Garage_.Name} Management---------", ConsoleColor.Cyan);
                Print($"Please navigate through the {garage.Garage_.Name} Garage menu by inputting the number \n(1, 2, 3, 4, 5, 6, 0) of your choice"
                    + "\n1. Park new vehicle"
                    + "\n2. Pick up vehicle"
                    + "\n3. List all parked vehicles"
                    + "\n4. List vehicle types"
                    + "\n5. Find vehicle via registration number"
                    + "\n6. Search for vehicles"
                    + "\n0. Exit to Previous menu");
                string input = ""; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = GetInput(); //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                {
                    Console.Clear();
                    ChangeConsoleColor("Please enter some input! \n", ConsoleColor.Red);
                }
                switch (input)
                {
                    case "1":
                        DisplayAddVehicleSubMenu(garage);
                        break;
                    case "2":
                        garage.PickUp();
                        break;
                    case "3":
                        garage.PrintAllVehicle();
                        break;
                    case "4":
                        garage.PrintVehicleType();
                        break;
                    case "5":
                        garage.FindvehicleViaRegistrationNumber();
                        break;
                    case "6":
                        DisplayVehicleSearchbMenu(garage);
                        break;
                    case "0":
                        DisplayGarageMenu(garage.GaragesList);
                        break;
                    default:
                        ChangeConsoleColor("Please enter some valid input (0, 1, 2, 3, 4, 5, 6)\n", ConsoleColor.Red);
                        DisplayGarageSubMenu(garage);
                        break;
                }
            }
        }
        public void DisplayAddVehicleSubMenu(GarageHandler garage)
        {
            while (true)
            {
                ChangeConsoleColor($"---------- Park new Vehicle----------\n", ConsoleColor.Cyan);
                Print($"For Park new vehicle in the {garage.Garage_.Name} Garage Select  type of vehicle by inputting the number \n(1, 2, 3, 4, 5, 0) of your choice"
                    + "\n1. Airplane"
                    + "\n2. Boat"
                    + "\n3. Bus"
                    + "\n4. Car"
                    + "\n5. Motorcycle"
                    + "\n0. Exit to Previous menu");
                string input = ""; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = GetInput(); //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                {
                    Console.Clear();
                    ChangeConsoleColor("Please enter some input! \n", ConsoleColor.Red);
                }
                switch (input)
                {
                    case "1":
                        ChangeConsoleColor("-------Airplane Information-------", ConsoleColor.Cyan);
                        Airplane airplane = new Airplane();
                        garage.Park(airplane, "Airplane");
                        break;
                    case "2":
                        ChangeConsoleColor("-------Boat Information-------", ConsoleColor.Cyan);
                        Boat boat = new Boat();
                        garage.Park(boat, "Boat");
                        break;
                    case "3":
                        ChangeConsoleColor("-------Bus Information-------", ConsoleColor.Cyan);
                        Bus bus = new Bus();
                        garage.Park(bus, "Bus");
                        break;
                    case "4":
                        ChangeConsoleColor("-------Car Information-------", ConsoleColor.Cyan);
                        Car car = new Car();
                        garage.Park(car, "Car");
                        break;
                    case "5":
                        ChangeConsoleColor("-------Motorcycle Information-------", ConsoleColor.Cyan);
                        Motorcycle motorcycle = new Motorcycle();
                        garage.Park(motorcycle, "Motorcycle");
                        break;
                    case "0":
                        DisplayGarageSubMenu(garage);
                        break;
                    default:
                        ChangeConsoleColor("Please enter some valid input (0, 1, 2, 3, 4, 5)\n", ConsoleColor.Red);
                        DisplayGarageSubMenu(garage);
                        break;
                }
                DisplayAddVehicleSubMenu(garage);
            }
        }
        public void DisplayVehicleSearchbMenu(GarageHandler garage)
        {
            while (true)
            {
                ChangeConsoleColor($"----------Vehicles Search----------", ConsoleColor.Cyan);
                Print($"For Search for vehicles based on properties  in the {garage.Garage_.Name} Garage Select  property of vehicle by inputting the number \n(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0) of your choice"
                    + "\n1. Registration Number"
                    + "\n2. Color"
                    + "\n3. Number Of Wheels"
                    + "\n4. Model Year"
                    + "\n5. Number Of Engines"
                    + "\n6. Length"
                    + "\n7. Number Of Seats"
                    + "\n8. Fuel Type"
                    + "\n9. Cylinder Volume"
                    + "\n10.Vehicle Type");
                ChangeConsoleColor("11.#### Show Search results ###", ConsoleColor.DarkYellow);
                Print("0. Exit to Previous menu");
                string input = ""; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = GetInput(); //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                {
                    Console.Clear();
                    ChangeConsoleColor("Please enter some input! \n", ConsoleColor.Red);
                }
                switch (input)
                {
                    case "1":
                        ChangeConsoleColor("-------Search with Registration Number-------", ConsoleColor.Cyan);
                        Print("Enter The Registration Number :");
                        filter.registrationNumber = GetInput();
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "2":
                        ChangeConsoleColor("-------Search With Color-------", ConsoleColor.Cyan);
                        Print("Enter The Color:");
                        filter.color = GetInput();
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "3":
                        ChangeConsoleColor("-------Search With Number Of Wheels-------", ConsoleColor.Cyan);
                        Print("Enter The Number Of Wheels:");
                        ValidInt(GetInput(), out filter.numberOfWheels);
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "4":
                        ChangeConsoleColor("-------Search With Model Year-------", ConsoleColor.Cyan);
                        Print("Enter The Model Year:");
                        ValidInt(GetInput(), out filter.modelYear);
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "5":
                        ChangeConsoleColor("-------Search With Number Of Engines-------", ConsoleColor.Cyan);
                        Print("Enter Number Of Engines:");
                        ValidInt(GetInput(), out filter.numberOfEngines);
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "6":
                        ChangeConsoleColor("-------Search With Boat length-------", ConsoleColor.Cyan);
                        Print("Enter Boat Length:");
                        ValidDouble(GetInput(), out filter.length);
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "7":
                        ChangeConsoleColor("-------Search With Number Of Seats-------", ConsoleColor.Cyan);
                        Print("Enter Number Of Seats:");
                        ValidInt(GetInput(), out filter.numberOfSeats);
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "8":
                        ChangeConsoleColor("-------Search With Car Fuel Type-------", ConsoleColor.Cyan);
                        Print($"Select Car fuel type  by inputting the number (1, 2)"
                               + "\n1. Gasoline"
                               + "\n2. Diesel");
                        string option = ""; //Creates the character input to be used with the switch-case below.
                        try
                        {
                            option = GetInput(); //Tries to set input to the first char in an input line
                        }
                        catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                        {
                            Console.Clear();
                            ChangeConsoleColor("Please enter some number! \n", ConsoleColor.Red);
                        }
                        switch (option)
                        {
                            case "1":
                                filter.fueltype = Fueltype.Gasoline;
                                break;
                            case "2":
                                filter.fueltype = Fueltype.Diesel;
                                break;
                            default:
                                ChangeConsoleColor("Please enter some valid number (1, 2)\n", ConsoleColor.Red);
                                break;
                        }
                        DisplayVehicleSearchbMenu(garage);
                        break;
                    case "9":
                        ChangeConsoleColor("-------Search With Cylinder Volume-------", ConsoleColor.Cyan);
                        Print("Enter Cylinder Volume:");
                        ValidInt(GetInput(), out filter.cylinderVolume);
                        DisplayVehicleSearchbMenu(garage);

                        break;
                    case "10":
                        ChangeConsoleColor("-------Search With Vehicle Type-------", ConsoleColor.Cyan);
                        while (true)
                        {
                            Print($"Search  with vehicle type by inputting the number of type \n(1, 2, 3, 4, 5, 0) of your choice"
                                + "\n1. Airplane"
                                + "\n2. Boat"
                                + "\n3. Bus"
                                + "\n4. Car"
                                + "\n5. Motorcycle"
                                + "\n0. Exit to Previous menu");
                            string answer = ""; //Creates the character input to be used with the switch-case below.
                            try
                            {
                                answer = GetInput(); //Tries to set input to the first char in an input line
                            }
                            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                            {
                                Console.Clear();
                                ChangeConsoleColor("Please enter some input! \n", ConsoleColor.Red);
                            }
                            switch (answer)
                            {
                                case "1":
                                    filter.vehicleType = "Airplane";
                                    DisplayVehicleSearchbMenu(garage);
                                    break;
                                case "2":
                                    filter.vehicleType = "Boat";
                                    DisplayVehicleSearchbMenu(garage);
                                    break;
                                case "3":
                                    filter.vehicleType = "Bus";
                                    DisplayVehicleSearchbMenu(garage);
                                    break;
                                case "4":
                                    filter.vehicleType = "Car";
                                    DisplayVehicleSearchbMenu(garage);
                                    break;
                                case "5":
                                    filter.vehicleType = "Motorcycle";
                                    DisplayVehicleSearchbMenu(garage);
                                    break;
                                case "0":
                                    DisplayGarageSubMenu(garage);
                                    break;
                                default:
                                    ChangeConsoleColor("Please enter some valid input (0, 1, 2, 3, 4, 5)\n", ConsoleColor.Red);
                                    DisplayVehicleSearchbMenu(garage);
                                    break;
                            }
                            DisplayVehicleSearchbMenu(garage);
                        }
                    case "11":
                        garage.FilterVehicles(filter, true);
                        break;
                    case "0":
                        DisplayGarageSubMenu(garage);
                        break;
                    default:
                        ChangeConsoleColor("Please enter some valid input ( 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10)\n", ConsoleColor.Red);
                        DisplayVehicleSearchbMenu(garage);
                        break;
                }
                DisplayVehicleSearchbMenu(garage);
            }
        }
        public void DisplayGarageMenu(List<GarageHandler> GaragesList)
        {
            GarageHandler garage = new GarageHandler();
            garage.GaragesList = GaragesList;
            while (true)
            {
                ChangeConsoleColor("---------Garages Management---------", ConsoleColor.Cyan);
                Print($"Please navigate through Garages Management Menu by inputting the number \n(1, 2, 3, 4, 0) of your choice"
                    + "\n1. Install new garage"
                    + "\n2. Uninstall garage"
                    + "\n3. List all garages"
                    + "\n4. Manage specific garage"
                    + "\n0. Exit the application");
                string input = ""; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = GetInput(); //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input !!
                {
                    Console.Clear();
                    ChangeConsoleColor("Please enter some input! \n", ConsoleColor.Red);
                }
                switch (input)
                {
                    case "1":
                        garage.InstallNewGarage();
                       
                        break;
                    case "2":
                            garage.UninstallGarage();
                        break;
                    case "3":
                        garage.PrintAllGarages();
                        break;
                    case "4":
                          garage.ManageGarage();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        ChangeConsoleColor("Please enter some valid input (0, 1, 2, 3, 4)\n", ConsoleColor.Red);
                         DisplayGarageMenu(GaragesList);
                        break;
                }
            }
        }
        #endregion
    }
}
