using System;

namespace Garage1.Vehicles
{
    public class Motorcycle : Vehicle
    {
        private int cylinderVolume;
        public int CylinderVolume { get => cylinderVolume; set => cylinderVolume = value; }
        public Motorcycle() : base()
        {
            SetCylinderVolume();
        }
        public Motorcycle(string registrationNumber, string color, int numberOfWheels, int modelYear, int cylinderVolume) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            CylinderVolume = cylinderVolume;
        }
        public override string ToString()
        {
            return base.ToString() + $"CylinderVolume:{CylinderVolume}";
        }

        void SetCylinderVolume()
        {
            int cylinderVolume = 0;
            bool check_cylinderVolume;
            ui.Print("Enter Cylinder Volume:");
            check_cylinderVolume = ui.ValidInt(ui.GetInput(), out cylinderVolume);
            if (check_cylinderVolume)
                this.CylinderVolume = cylinderVolume;
            else
                SetCylinderVolume();
        }
        public override Type GetSubType()
        {
            return GetType();
        }
    }
}
