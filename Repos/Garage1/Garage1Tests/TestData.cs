using Garage1;
using Garage1.Vehicles;

namespace Garage1Tests
{
    public class TestData
    {

        public Airplane GetAirplaneObject()
        {
            const string registrationNumber = "AIR123";
            const string color = "White";
            const int numberOfWheels = 8;
            const int modelYear = 2014;
            const int numberOfEngines = 6;
            Airplane airplane = new Airplane(registrationNumber, color, numberOfWheels, modelYear, numberOfEngines);
            return airplane;

        }
        public Airplane GetAirplaneObject_NO2()
        {
            const string registrationNumber = "Ria680";
            const string color = "White";
            const int numberOfWheels = 8;
            const int modelYear = 2014;
            const int numberOfEngines = 6;
            Airplane airplane = new Airplane(registrationNumber, color, numberOfWheels, modelYear, numberOfEngines);
            return airplane;

        }
        public Boat GetBoatObject()
        {
            const string registrationNumber = "Bot321";
            const string color = "Blue";
            const int numberOfWheels = 1;
            const int modelYear = 2010;
            const double length = 600.5;
            Boat boat = new Boat(registrationNumber, color, numberOfWheels, modelYear, length);
            return boat;

        }
        public Bus GetBusObject()
        {
            const string registrationNumber = "BUS678";
            const string color = "Red";
            const int numberOfWheels = 8;
            const int modelYear = 2005;
            const int numberOfSeats = 45;
            Bus bus = new Bus(registrationNumber, color, numberOfWheels, modelYear, numberOfSeats);
            return bus;

        }
        public Car GetCarObject()
        {
            const string registrationNumber = "CAR456";
            const string color = "Red";
            const int numberOfWheels = 8;
            const int modelYear = 2014;
            const Fueltype fueltype = Fueltype.Diesel;
            Car car = new Car(registrationNumber, color, numberOfWheels, modelYear, fueltype);
            return car;

        }
        public Car GetCarObject_NO2()
        {
            const string registrationNumber = "RAC_987";
            const string color = "Black";
            const int numberOfWheels = 4;
            const int modelYear = 2019;
            const Fueltype fueltype = Fueltype.Gasoline;
            Car car = new Car(registrationNumber, color, numberOfWheels, modelYear, fueltype);
            return car;

        }
        public Motorcycle GetMotorcycleObject()
        {
            const string registrationNumber = "MOT654";
            const string color = "Black";
            const int numberOfWheels = 2;
            const int modelYear = 2020;
            const int cylinderVolume = 4;
            Motorcycle motorcycle = new Motorcycle(registrationNumber, color, numberOfWheels, modelYear, cylinderVolume);
            return motorcycle;

        }
        public GarageHandler CreateGarageWithVehicles()
        {
            Garage1.GarageHandler TestGarage = new GarageHandler(6, "Test Garage");
            TestGarage.Garage_.AddVehicle(GetAirplaneObject(), 0);
            TestGarage.Garage_.AddVehicle(GetBoatObject(), 1);
            TestGarage.Garage_.AddVehicle(GetBusObject(), 2);
            TestGarage.Garage_.AddVehicle(GetCarObject(), 3);
            TestGarage.Garage_.AddVehicle(GetCarObject_NO2(), 4);
            TestGarage.Garage_.AddVehicle(GetMotorcycleObject(), 5);
            return TestGarage;
        }
        public Filter GetFilterClassObject()
        {
            Filter filterClass = new Filter();
            filterClass.color = "Red";
            filterClass.numberOfWheels = 8;
            return filterClass;
        }
    }
}
