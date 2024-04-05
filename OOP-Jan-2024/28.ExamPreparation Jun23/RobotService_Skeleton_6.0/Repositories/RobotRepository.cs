using System;
using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models() => robots.AsReadOnly();

        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public bool RemoveByName(string robotModel) => robots.Remove(robots.FirstOrDefault(x => x.Model == robotModel));

        public IRobot FindByStandard(int interfaceStandard) => robots.FirstOrDefault(i => i.InterfaceStandards.Contains(interfaceStandard));

    }
}

