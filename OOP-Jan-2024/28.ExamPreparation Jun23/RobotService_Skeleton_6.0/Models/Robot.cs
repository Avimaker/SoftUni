using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
	public abstract class Robot : IRobot
	{
        private string _model;
        private int _batteryCapacity;
        private int _batteryLevel;
        private int _convertionCapacityIndex;
        private List<int> _interfaceStandards;

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            _batteryLevel = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            _interfaceStandards = new List<int>();
        }

        public string Model
        {
            get { return this._model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }
                this._model = value;
            }
        }

        public int BatteryCapacity
        {
            get { return this._batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }
                this._batteryCapacity = value;
            }
        }

        // Todo = _batteryCapacity when new robot
        public int BatteryLevel
        {
            get { return this._batteryLevel; }
            private set { this._batteryLevel = value; } 
        }

        public int ConvertionCapacityIndex
        {
            get { return this._convertionCapacityIndex; }
            private set { this._convertionCapacityIndex = value; }
        }

        // repository 
        public IReadOnlyCollection<int> InterfaceStandards => _interfaceStandards.AsReadOnly();


        public void Eating(int minutes)
        {
            int producedEnergy = _convertionCapacityIndex * minutes;

            if (producedEnergy <= (_batteryCapacity - _batteryLevel))
            {
                BatteryLevel += producedEnergy;
            }
            else
            {
                BatteryLevel = _batteryCapacity;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;//field or not?
            _interfaceStandards.Add(supplement.InterfaceStandard);
        }
       
        public bool ExecuteService(int consumedEnergy)
        {
            if (_batteryLevel >= consumedEnergy)
            {
                _batteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {_batteryCapacity}");
            sb.AppendLine($"--Current battery level: {_batteryLevel}");
            sb.Append($"--Supplements installed: ");

            if (_interfaceStandards.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                sb.Append(string.Join(" ", _interfaceStandards));
            }

            return sb.ToString().TrimEnd();

        }
    }
}

