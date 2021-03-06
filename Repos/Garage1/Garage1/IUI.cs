using System;
using System.Collections.Generic;

namespace Garage1
{
    interface IUI
    {

        string GetInput();
        void Print(string message);
        void DisplayGarageSubMenu(GarageHandler garage);
        void DisplayAddVehicleSubMenu(GarageHandler garage);
        void ChangeConsoleColor(string message, ConsoleColor color);
        bool ValidString(string message);
        bool ValidInt(string message, out int number);
        bool ValidDouble(string message, out double number);
        void DisplayGarageMenu(List<GarageHandler> GaragesList);
    }
}
