using System;
using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            users = new List<IUser>();
        }

        public IReadOnlyCollection<IUser> GetAll() => users.AsReadOnly();

        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            return users.Remove(users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier));
        }

        public IUser FindById(string identifier)
        {
            return users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        }

    }
}

