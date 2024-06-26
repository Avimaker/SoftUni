﻿

using System.Collections.Generic;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        //private List<IDelicacy> delicacies = new();// !!! не работи
        private List<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => delicacies.AsReadOnly();

        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}

