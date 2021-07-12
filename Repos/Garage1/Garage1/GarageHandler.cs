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
        public List<Garage<IVehicle>> GarageList { get; set; }
        IUI ui = new ConsoleUI();
        #region Constructors
        public GarageHandler()
        {

        }
        public GarageHandler(int capacity, string name)
        {
            Garage_ = new Garage<IVehicle>(capacity, name);
        }
        #endregion
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
        public string Park(IVehicle item, string vehicleType)
        {
            string outputMessage = "";
            int VehicleCount = (from v in Garage_
                                where v is null
                                select v).Count();

            int ExistVehicleCount = (from v in Garage_
                                     where v != null && v.RegistrationNumber.Trim().Equals(item.RegistrationNumber.Trim(), StringComparison.OrdinalIgnoreCase)
                                     select v).Count();

            if (ExistVehicleCount > 0)
            {
                outputMessage = $"There is another {vehicleType}  with same Registration Number\n";
                ui.ChangeConsoleColor(outputMessage, ConsoleColor.Red);

            }
            else if (VehicleCount == 0)
            {
                outputMessage = $"There is no space in the garage \n";
                ui.ChangeConsoleColor($"There is no space in the garage \n", ConsoleColor.Red);
            }
            else
            {
                foreach (var v in from v in Garage_
                                  where v is null
                                  select v)
                {
                    _ = Garage_.AddVehicle(item, Garage_.ToList().IndexOf(v));
                    outputMessage = $"Successfully Parked the {vehicleType} \n";
                    ui.ChangeConsoleColor($"Successfully Parked the {vehicleType} \n", ConsoleColor.Green);
                    break;
                }
            }
            return outputMessage;
        }
        public int FilterVehicles(Filter filter, bool EnableUserInteraction)
        {
            #region  Get Filter criteria
            List<Predicate<IVehicle>> predicate = new List<Predicate<IVehicle>>();
            if (filter.registrationNumber != null) predicate.Add(m => m != null && m.RegistrationNumber.Equals(filter.registrationNumber.Trim(), StringComparison.OrdinalIgnoreCase));
            if (filter.color != null) predicate.Add(m => m != null && m.Color.Equals(filter.color.Trim(), StringComparison.OrdinalIgnoreCase));
            if (filter.numberOfWheels != 0) predicate.Add(m => m != null && m.NumberOfWheels.Equals(filter.numberOfWheels));
            if (filter.modelYear != 0) predicate.Add(m => m != null && m.ModelYear.Equals(filter.modelYear));
            if (filter.type != null) predicate.Add(m => m != null && m.GetSubType().Name.Equals(filter.type.Trim(), StringComparison.OrdinalIgnoreCase));
            if (filter.numberOfEngines != 0) predicate.Add(m => m != null && m.GetSubType().Name.Equals("Airplane") && m.CastTo<Airplane>().NumberOfEngines.Equals(filter.numberOfEngines));
            if (filter.length != 0) predicate.Add(m => m != null && m.GetSubType().Name.Equals("Boat") && m.CastTo<Boat>().Length.Equals(filter.length));
            if (filter.numberOfSeats != 0) predicate.Add(m => m != null && m.GetSubType().Name.Equals("Bus") && m.CastTo<Bus>().NumberOfSeats.Equals(filter.numberOfSeats));
            if (filter.fueltype != 0) predicate.Add(m => m != null && m.GetSubType().Name.Equals("Car") && m.CastTo<Car>().FuelType.Equals(filter.fueltype));
            if (filter.cylinderVolume != 0) predicate.Add(m => m != null && m.GetSubType().Name.Equals("Motorcycle") && m.CastTo<Motorcycle>().CylinderVolume.Equals(filter.cylinderVolume));
            #endregion
            var query = Garage_.Filter(predicate);
            var enumerator = query.GetEnumerator();
            if (EnableUserInteraction)
            {
                ui.ChangeConsoleColor("------------Show Search results------------", ConsoleColor.DarkYellow);
                while (enumerator.MoveNext())
                {
                    ui.Print(enumerator.Current.ToString());
                }
                ui.Print("");
            }
            return query.Count();
        }
        #region Search By Registration Number
        public void FindvehicleViaRegistrationNumber()
        {
            string registrationNumber;
            ui.ChangeConsoleColor($"---------- Find vehicle via registration number----------\n", ConsoleColor.Cyan);
            ui.Print("Enter vehicle's Registration Number:");
            registrationNumber = ui.GetInput();
            SearchByRegistrationNumber(registrationNumber,true);
        }
        public int SearchByRegistrationNumber(string registrationNumber, bool EnableUserInteraction)
        {
            string outputMessage = "";
            bool check_registrationNumber;
            int VehiclesCount = 0;
            check_registrationNumber = ui.ValidString(registrationNumber);
            if (check_registrationNumber)
            {
                var query = Garage_.Filter(m => m != null && m.RegistrationNumber.Trim().Equals(registrationNumber.Trim(), StringComparison.OrdinalIgnoreCase));
                VehiclesCount = query.Count();
                if (VehiclesCount > 0)
                {
                    var enumerator = query.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (EnableUserInteraction)
                        {
                            ui.ChangeConsoleColor($"---------- Vehicles Information----------\n", ConsoleColor.DarkYellow);
                        ui.Print(enumerator.Current.ToString()); 
                        }
                    }
                    ui.Print("");
                }
                else
                {
                    outputMessage = $"There is no vehicle with this Registration Number \n";
                    ui.ChangeConsoleColor(outputMessage, ConsoleColor.Red);
                }
                if (EnableUserInteraction)
                    ui.DisplayGarageSubMenu(this);
            }
            else
            {
                outputMessage = $"Enter valid  Registration Number !!\n";
                ui.ChangeConsoleColor(outputMessage, ConsoleColor.Red);
                if (EnableUserInteraction)
                    ui.DisplayGarageSubMenu(this);
            }
            return VehiclesCount;
        }
        #endregion

        #region Install Garage
        public GarageHandler CreateGrarageObject(int capacity, string name)
        {
            GarageHandler garage = new GarageHandler(capacity, name);
            return garage;
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
            ui.ChangeConsoleColor($"Successfully installed {name} garage\n", ConsoleColor.Green);
            ui.DisplayGarageSubMenu(CreateGrarageObject(capacity, name));
        }
        #endregion

        #region RemoveVehicle
        public string RemoveVehicleFromGarage(string registrationNumber, bool EnableUserInteraction)
        {
            string outputMessage = "";
            bool check_registrationNumber;
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
                        outputMessage = $"Successfully Pick Up the Vehicle with Registration Number {registrationNumber} \n";
                        ui.ChangeConsoleColor(outputMessage, ConsoleColor.Green);
                        break;
                    }
                }
                else
                {
                    outputMessage = $"There is no vehicle with this Registration Number \n";
                    ui.ChangeConsoleColor(outputMessage, ConsoleColor.Red);
                }
                if (EnableUserInteraction)
                    ui.DisplayGarageSubMenu(this);
            }
            else
            {
                outputMessage = $"Enter valid  Registration Number !!\n";
                ui.ChangeConsoleColor(outputMessage, ConsoleColor.Red);
                if (EnableUserInteraction)
                    PickUp();
            }
            return outputMessage;
        }
        public void PickUp()
        {
            string registrationNumber;
            ui.ChangeConsoleColor($"---------- Pick up Vehicle----------\n", ConsoleColor.Cyan);
            ui.Print("For Pick up vehicle... Enter vehicle's Registration Number:");
            registrationNumber = ui.GetInput();
            RemoveVehicleFromGarage(registrationNumber, true);
        }
        #endregion
    }
}
