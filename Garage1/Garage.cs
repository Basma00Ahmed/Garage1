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
        protected Vehicle[] VehiclesList;

        public int Capacity => capacity;
        public int Count => VehiclesList.Length;
        public bool IsFull => capacity <= Count;

        Random number=new Random ();
        public string Name { get => name; set => name =value ?? $"Garage{number}"; }

        public Garage(int capacity,string name)
        {
            Name = name;
            this.capacity = Math.Max(1, capacity);
            VehiclesList = new  List<Vehicle>(this.capacity).ToArray();
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
        public virtual bool AddVehicle(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (IsFull) return false;

            VehiclesList[VehiclesList.Length-1] = item as Vehicle;
            return true;
        }

        public override string ToString()
        {
            return $"Garage Name:{Name}   Garage Capacity:{capacity}.";
        }
       

    }
}
