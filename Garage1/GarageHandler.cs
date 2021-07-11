using Garage1.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Garage1
{
    public class GarageHandler
    {
        public Garage<IVehicle> Garage_ { get; set; }
        IUI ui = new ConsoleUI();
        public GarageHandler()
        {

        }
        public GarageHandler(int capacity, string name)
        {
            Garage_ = new Garage<IVehicle>(capacity, name);
        }
        public void PrintAllVehicle()
        {
            ui.ChangeConsoleColor($"----------List of all parked vehicles----------\n", ConsoleColor.Yellow);
            var query = from v in Garage_
                        where v != null
                        select v;
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    ui.Print(item.ToString());
                }
            }
            else
                ui.ChangeConsoleColor($"There is no vehicle in the garage \n", ConsoleColor.Red);
            ui.Print("");
        }
        public void Park(IVehicle item, string vehicleType)
        {
           
            int VehicleCount = (from v in Garage_
                                where v is null
                                select v).Count();

            int ExistVehicleCount = (from v in Garage_
                                     where v != null && v.RegistrationNumber.Trim().Equals(item.RegistrationNumber.Trim(), StringComparison.OrdinalIgnoreCase)
                                     select v).Count();

            if (ExistVehicleCount > 0)
            {
                ui.ChangeConsoleColor($"There is another {vehicleType}  with same Registration Number\n", ConsoleColor.Red);

            }
            else if (VehicleCount == 0)
            {
                ui.ChangeConsoleColor($"There is no space in the garage \n", ConsoleColor.Red);
            }
            else
            {
                foreach (var v in from v in Garage_
                                  where v is null
                                  select v)
                {
                    _ = Garage_.AddVehicle(item, Garage_.ToList().IndexOf(v));
                    ui.ChangeConsoleColor($"Successfully Parked the {vehicleType} \n", ConsoleColor.Green);
                    break;
                }
            }
        }
        public void PickUp()
        {
            bool check_registrationNumber;
            string registrationNumber;
            ui.ChangeConsoleColor($"---------- Pick up Vehicle----------\n", ConsoleColor.Cyan);
            ui.Print("For Pick up vehicle... Enter vehicle's Registration Number:");
            registrationNumber = ui.GetInput();
            check_registrationNumber = ui.ValidString(registrationNumber);
            if (check_registrationNumber)
            {
                var query = from v in Garage_
                            where v != null && v.RegistrationNumber.Trim().Equals(registrationNumber.Trim(), StringComparison.OrdinalIgnoreCase)
                            select v;
                if (query.Count() > 0)
                {
                    foreach (var v in query)
                    {
                        _ = Garage_.RemoveVehicle(Garage_.ToList().IndexOf(v));

                        ui.ChangeConsoleColor($"Successfully Pick Up the Vehicle with Registration Number {registrationNumber} \n", ConsoleColor.Green);
                        break;
                    }
                }
                else
                    ui.ChangeConsoleColor($"There is no vehicle in the garage \n", ConsoleColor.Red);
                ui.DisplayGarageSubMenu(this);
            }
            else
            {
                ui.ChangeConsoleColor($"There is no vehicle with this Registration Number \n", ConsoleColor.Red);
                PickUp();
            }
        }
        public void FilterVehicles(Filter filter)
        {
            List<Predicate<IVehicle>> predicate = new List<Predicate<IVehicle>>();
            if (filter.registrationNumber != null) predicate.Add(m => m != null && m.CastTo <IVehicle>().RegistrationNumber.Equals(filter.registrationNumber.Trim(), StringComparison.OrdinalIgnoreCase));
            if (filter.color != null) predicate.Add(m => m != null && m.CastTo<IVehicle>().Color.Equals(filter.color.Trim(), StringComparison.OrdinalIgnoreCase));
            if (filter.numberOfWheels != 0) predicate.Add(m => m != null && m.CastTo<IVehicle>().NumberOfWheels.Equals(filter.numberOfWheels));
            if (filter.modelYear != 0) predicate.Add(m => m != null && m.CastTo<IVehicle>().ModelYear.Equals(filter.modelYear));
            if (filter.type != null) predicate.Add(m => m != null && m.GetSubType().ToString().Equals(filter.type.Trim(), StringComparison.OrdinalIgnoreCase));
            if (filter.numberOfEngines != 0) predicate.Add(m => m != null && m.CastTo<Airplane>().NumberOfEngines.Equals(filter.numberOfEngines));
            if (filter.length != 0)
            { 

            predicate.Add(m =>   m != null && m.CastTo<Boat>().Length.Equals(filter.length)   );
        }
            if (filter.numberOfSeats != 0) predicate.Add(m => m != null && m.CastTo<Bus>().NumberOfSeats.Equals(filter.numberOfSeats));
            if (filter.fueltype != 0) predicate.Add(m => m != null && m.CastTo<Car>().FuelType.Equals(filter.fueltype));
            if (filter.cylinderVolume != 0) predicate.Add(m => m != null && m.CastTo<Motorcycle>().CylinderVolume.Equals(filter.cylinderVolume));

   

            var query = Garage_.Filter(predicate);
            var enumerator = query.GetEnumerator();
            ui.ChangeConsoleColor("------------Show Search results------------", ConsoleColor.DarkYellow);
            while (enumerator.MoveNext())
            {
                ui.Print(enumerator.Current.ToString());
            }
            ui.Print("");
        }
        public void PrintVehicleType()
        {
            ui.ChangeConsoleColor($"----------List of all vehicle types----------\n", ConsoleColor.Cyan);
            var query = from item in Garage_
                        where item != null
                        group item by item.GetSubType().ToString() into g
                        select new
                        {
                            Type = g.Key.ToString().Substring(g.Key.ToString().LastIndexOf('.') + 1),
                            Count = g.Count().ToString()
                        };
            if (query.Count() > 0)
            {
                foreach (var v in query)

                {
                    ui.Print(v.ToString());
                }
            }
            else
                ui.ChangeConsoleColor($"There is no vehicle with this type \n", ConsoleColor.Red);

            ui.Print("");
            ui.DisplayGarageSubMenu(this);
        }
        public void FindvehicleViaRegistrationNumber()
        {
            bool check_registrationNumber;
            string registrationNumber;
            ui.ChangeConsoleColor($"---------- Find vehicle via registration number----------\n", ConsoleColor.Cyan);
            ui.Print("Enter vehicle's Registration Number:");
            registrationNumber = ui.GetInput();

            check_registrationNumber = ui.ValidString(registrationNumber);
            if (check_registrationNumber)
            {
                var query = Garage_.Filter(m => m != null && m.RegistrationNumber.Trim().Equals(registrationNumber.Trim(), StringComparison.OrdinalIgnoreCase));
                if (query.Count() > 0)
                {
                    var enumerator = query.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ui.ChangeConsoleColor($"---------- Vehicles Information----------\n", ConsoleColor.DarkYellow);
                        ui.Print(enumerator.Current.ToString());
                    }
                    ui.Print("");
                }
                else
                    ui.ChangeConsoleColor($"There is no vehicle with this Registration Number \n", ConsoleColor.Red);
                ui.DisplayGarageSubMenu(this);

            }
            else
            {
                ui.ChangeConsoleColor($"There is no vehicle with this Registration Number \n", ConsoleColor.Red);
                ui.DisplayGarageSubMenu(this);
            }
        }
        public void InstallNewGarage()
        {
            string name;
            int capacity = 0;
            bool intCheck;
            bool check_Name;
            ui.ChangeConsoleColor("---------Welcome To  Garage Project---------", ConsoleColor.Cyan);
            ui.Print("Enter Garage Name : ");
            name = ui.GetInput();
            check_Name = ui.ValidString(name);
            if (check_Name == false)
                InstallNewGarage();
            ui.Print("Enter Garage Capacity : ");
            intCheck = ui.ValidInt(ui.GetInput(), out capacity);
            if (intCheck == false)
                InstallNewGarage();
            GarageHandler garage = new GarageHandler(capacity, name);
            ui.ChangeConsoleColor($"Successfully installed {name} garage\n", ConsoleColor.Green);
            ui.DisplayGarageSubMenu(garage);
        }

    }
}
