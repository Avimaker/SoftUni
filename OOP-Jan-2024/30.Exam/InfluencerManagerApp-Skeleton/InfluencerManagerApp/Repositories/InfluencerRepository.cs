using System;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {

        private List<IInfluencer> influencers;

        public InfluencerRepository()
        {
            influencers = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => influencers.AsReadOnly();

        public void AddModel(IInfluencer model)
        {
            influencers.Add(model);
        }

        public bool RemoveModel(IInfluencer model)
        {
            return influencers.Remove(influencers.FirstOrDefault(i => i.Username == model.Username));

        }

        public IInfluencer FindByName(string name)
        {
            return influencers.FirstOrDefault(i => i.Username == name);
        }
    }
}

