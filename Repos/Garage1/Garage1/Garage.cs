using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Garage1.Vehicles;

namespace Garage1
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private int capacity;
        private string name;
        protected T[] VehiclesList;
        private IUI ui = new ConsoleUI();
        public int Capacity => capacity;
        Random number = new Random();
        public string Name { get => name; set => name = value ?? $"Garage{number}"; }
        public Garage(int capacity, string name)
        {
            Name = name;
            this.capacity = Math.Max(1, capacity);
            VehiclesList = new T[(this.capacity)];

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in VehiclesList)
            {
                //.....

                yield return item;
            }
        }
        public bool AddVehicle(T item, int indx)
        {
            VehiclesList.SetValue(item, indx);
            return true;
        }
        public bool RemoveVehicle(int indx)
        {
            VehiclesList.SetValue(null, indx);
            return true;
        }
        public override string ToString()
        {
            return $"Garage Name:{Name}   Garage Capacity:{capacity}.";
        }
    }
}
