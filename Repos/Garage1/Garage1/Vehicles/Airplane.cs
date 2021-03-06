using System;

namespace Garage1.Vehicles
{
    public class Airplane : Vehicle
    {
        private int numberOfEngines;
        public int NumberOfEngines { get => numberOfEngines; set => numberOfEngines = value; }
        public Airplane() : base()
        {
            SetNumberOfEngines();
        }
        public Airplane(string registrationNumber, string color, int numberOfWheels, int modelYear, int numberOfEngines) : base(registrationNumber, color, numberOfWheels, modelYear)
        {
            NumberOfEngines = numberOfEngines;
        }
        public override string ToString()
        {
            return base.ToString() + $"Number Of Engines:{NumberOfEngines}";
        }

        void SetNumberOfEngines()
        {
            int numberOfEngines = 0;
            bool check_numberOfEngines;
            ui.Print("Enter Number Of Engines:");
            check_numberOfEngines = ui.ValidInt(ui.GetInput(), out numberOfEngines);
            if (check_numberOfEngines)
                this.NumberOfEngines = numberOfEngines;
            else
                SetNumberOfEngines();
        }
        public override Type GetSubType()
        {
            return GetType();
        }
    }
}
