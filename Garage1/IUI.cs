using System;
using System.Collections.Generic;
using System.Text;
using Garage1.Vehicles;

namespace Garage1
{
    interface IUI
    {
        ConsoleColor Color { get; set; }
        string GetInput();
        void Print(Vehicle vehicle);
        void Print(string message);
        void DisplayGarageSubMenu(Garage<Vehicle> garage);
        void DisplayAddVehicleSubMenu(Garage<Vehicle> garage);
        void InstallNewGarage();
        void ChangeConsoleColor(string message, ConsoleColor color);
        bool ValidString(string message);
        bool ValidInt(string message,out int number);
        bool ValidDouble(string message,out double number);
    }
}
