using Garage1.Vehicles;
using System;
using System.Collections.Generic;

namespace Garage1
{
    class Program
    {

        static void Main(string[] args)
        {
            IUI ui = new ConsoleUI();
            List<GarageHandler> GaragesList = new List<GarageHandler>();
            ui.DisplayGarageMenu(GaragesList);
        }

    }
}
    