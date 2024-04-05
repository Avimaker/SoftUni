using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<ISupplement> supplements;
        private IRepository<IRobot> robots;
        private string[] validRobotTypes = { "DomesticAssistant", "IndustrialAssistant" };
        private string[] validSupplementTypes = { "SpecializedArm", "LaserRadar" };

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            ////Var1
            //if (typeName == nameof(DomesticAssistant))
            //{
            //    robots.AddNew(new DomesticAssistant(model));
            //}
            //else if (typeName == nameof(IndustrialAssistant))
            //{
            //    robots.AddNew(new IndustrialAssistant(model));
            //}
            //else
            //{
            //    return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            //    //return $"Robot type {typeName} cannot be created.";
            //}

            //return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
            ////return $"{typeName} {model} is created and added to the RobotRepository.";

            //Var2
            if (!validRobotTypes.Contains(typeName))
            {
                return $"Robot type {typeName} cannot be created.";
            }

            IRobot robot = null;

            switch (typeName)
            {
                case "DomesticAssistant":
                    robot = new DomesticAssistant(model);
                    break;
                case "IndustrialAssistant":
                    robot = new IndustrialAssistant(model);
                    break;
            }

            robots.AddNew(robot);

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (!validSupplementTypes.Contains(typeName))
            {
                return $"{typeName} is not compatible with our robots.";
            }

            ISupplement supplement = null;

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }

            supplements.AddNew(supplement);
            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            //models връща всичко от вътрешната колекция
            ISupplement supplement = supplements
                .Models()
                .FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            //дай ми първия чието име е равно на supplementTypeName

            IRobot robot = robots
                .Models()
                .FirstOrDefault(r => r.Model == model && !r.InterfaceStandards.Contains(supplement.InterfaceStandard));
            //дай ми първия който отговаря на търсения модел и няма инсталиран подадения ъпгрейд
            if (robot == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robot.InstallSupplement(supplement); //инсталирам частта
            supplements.RemoveByName(supplementTypeName);//махам я от листа

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            //IEnumerable<IRobot> filteredRobots = robots
            //    .Models()
            //    .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
            //    .OrderByDescending(b => b.BatteryLevel);

            //if (!filteredRobots.Any())
            //{
            //    return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            //}

            //int availablePower = filteredRobots.Sum(b => b.BatteryLevel);

            //if (availablePower < totalPowerNeeded)
            //{
            //    return string.Format(OutputMessages.MorePowerNeeded, serviceName, (totalPowerNeeded - availablePower));
            //}

            //int robotCounter = 0;

            //foreach (var robot in filteredRobots)
            //{
            //    robotCounter++;

            //    if (robot.BatteryLevel >= totalPowerNeeded)
            //    {
            //        robot.ExecuteService(totalPowerNeeded);
            //        break;
            //    }

            //    totalPowerNeeded -= robot.BatteryLevel;
            //    robot.ExecuteService(totalPowerNeeded);

            //}

            //return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCounter);

            var selectedRobots = this.robots.Models().Where(r => r.InterfaceStandards.Any(i => i == intefaceStandard)).OrderByDescending(y => y.BatteryLevel);

            if (selectedRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int powerSum = selectedRobots.Sum(r => r.BatteryLevel);

            if (powerSum < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - powerSum);
            }

            int usedRobotsCount = 0;

            foreach (var robot in selectedRobots)
            {
                usedRobotsCount++;

                if (totalPowerNeeded <= robot.BatteryLevel)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                }

            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobotsCount);

        }

        public string RobotRecovery(string model, int minutes)
        {
            IEnumerable<IRobot> filteredRobots = robots
               .Models()
               .Where(r => r.Model == model && r.BatteryLevel * 2 < r.BatteryCapacity);

            int robotsCount = 0;

            foreach (var robot in filteredRobots)
            {
                robot.Eating(minutes);
                robotsCount++;
            }

            return string.Format(OutputMessages.RobotsFed, robotsCount);

            //var selectedRobots = this.robots.Models().Where(r => r.Model == model && r.BatteryLevel * 2 < r.BatteryCapacity);
            //int robotsFed = 0;

            //foreach (var robot in selectedRobots)
            //{
            //    robot.Eating(minutes);
            //    robotsFed++;
            //}

            //return string.Format(OutputMessages.RobotsFed, robotsFed);
        }

        public string Report()
        {
            IEnumerable<IRobot> filteredRobots = robots
                .Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            StringBuilder sb = new StringBuilder();

            foreach (var robot in filteredRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }



    }
}

