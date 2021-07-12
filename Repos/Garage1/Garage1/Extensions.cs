using Garage1.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage1
{
    public static class Extensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, List<Predicate<T>> predicates) //where T : IVehicle
        {
            List<T> L = new List<T>();
            foreach (T item in source)
            {
                bool pass = true;
                foreach (Predicate<T> p in predicates)
                {
                    if (!(p(item)))
                    {
                        pass = false;
                        break;
                    }
                }
                if (pass) L.Add(item);
            }
            return L;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                              Func<T, bool> predicate)
        {
            foreach (var item in source)
            {

                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        public static T CastTo<T>(this object o)
        {
            T o1 = (T)o;
            return o1;
        }
    }
}
