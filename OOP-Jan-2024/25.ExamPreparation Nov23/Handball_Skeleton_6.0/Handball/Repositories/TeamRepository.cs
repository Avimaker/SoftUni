﻿using System.Collections.Generic;
using System.Linq;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;

        public TeamRepository()
        {
            teams = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models
            => teams.AsReadOnly();

        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool ExistsModel(string name)
            => teams.Any(t => t.Name == name);

        public ITeam GetModel(string name)
            => teams.FirstOrDefault(t => t.Name == name);

        public bool RemoveModel(string name)
            => teams.Remove(teams.FirstOrDefault(t => t.Name == name));
    }
}

