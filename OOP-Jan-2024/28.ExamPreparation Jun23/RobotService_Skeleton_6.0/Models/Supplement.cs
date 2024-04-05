using System;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        private int interfaceStandard;
        private int batteryUsage;

        protected Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        public int InterfaceStandard
        {
            get { return this.interfaceStandard; }
            private set { this.interfaceStandard = value; }
        }

        public int BatteryUsage
        {
            get { return this.batteryUsage; }
            private set { this.batteryUsage = value; }
        }

    }
}

