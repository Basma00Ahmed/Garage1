using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Garage1.Vehicles;

namespace Garage1
{
    public class Garage<T> : IEnumerable<T>
    {
        private int capacity;
        private string name;
        protected IVehicle[] VehiclesList;
         IUI ui = new ConsoleUI();

        public int Capacity => capacity;
        public int Count => VehiclesList.Length;
        public bool IsFull => capacity <= Count;

        Random number=new Random ();
        public string Name { get => name; set => name =value ?? $"Garage{number}"; }

        public Garage(int capacity,string name)
        {
            Name = name;
            this.capacity = Math.Max(1, capacity);
            VehiclesList = new  List<IVehicle>(this.capacity).ToArray();
            

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in VehiclesList)
            {
                //.....
                yield return (T)(IEnumerator<T>)item  ;
            }
        }
        public bool AddVehicle(T item,string vehicleName)
        {
            IVehicle vehicle = item as IVehicle;
            int ExistVehicleCount = (from v in VehiclesList
                                     where v.RegistrationNumber.Trim().Equals(vehicle.RegistrationNumber.Trim(), StringComparison.OrdinalIgnoreCase)
                                     select v).Count();

            if (ExistVehicleCount > 0)
            {
                ui.ChangeConsoleColor($"There is another {vehicleName}  with same Registration Number\n", ConsoleColor.Green);
                return false;
            }
            else if (IsFull)
            {
                ui.ChangeConsoleColor($"There is no space in the garage \n", ConsoleColor.Green);
                return false;
            }
            else
            {
                if (VehiclesList.Length  > 0)
                { 
                    Array.Resize<IVehicle>(ref VehiclesList, VehiclesList.Length + 1);
                    VehiclesList[VehiclesList.Length-1] = vehicle;
                 }
                else
                { 
                    VehiclesList = new IVehicle[1];
                    VehiclesList[0]=vehicle;
                }
                ui.ChangeConsoleColor($"Successfully Parked the {vehicleName} \n", ConsoleColor.Green);

                return true;
            }
        }

        public override string ToString()
        {
            return $"Garage Name:{Name}   Garage Capacity:{capacity}.";
        }
       

    }
}
