using System;

namespace Garage1
{
    class Program
    {
        static IUI ui = new ConsoleUI();
        static void Main(string[] args)
        {
            
            ui.InstallNewGarage();
        }
    }
}
