using System;
namespace Garage1.Vehicles
{
    public interface IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public int ModelYear { get; set; }
        public void SetRegistrationNumber();
        public void SetColor();
        public void SetNumberOfWheels();
        public void SetModelYear();
        public abstract Type GetSubType();
    }
}
