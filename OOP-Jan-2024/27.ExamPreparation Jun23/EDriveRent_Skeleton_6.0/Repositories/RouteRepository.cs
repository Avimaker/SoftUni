using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private List<IRoute> routes;

        public RouteRepository()
        {
            routes = new List<IRoute>();
        }

        public IReadOnlyCollection<IRoute> GetAll() => routes.AsReadOnly();

        public void AddModel(IRoute model)
        {
            routes.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            return routes.Remove(routes.FirstOrDefault(r => r.RouteId == int.Parse(identifier)));
        }

        public IRoute FindById(string identifier)
        {
            return routes.FirstOrDefault(r => r.RouteId == int.Parse(identifier));
        }

    }
}

