using System;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {

        private List<ICampaign> campaigns;

        public CampaignRepository()
        {
            campaigns = new List<ICampaign>();
        }

        public IReadOnlyCollection<ICampaign> Models => campaigns.AsReadOnly();

        public void AddModel(ICampaign model)
        {
            campaigns.Add(model);
        }

        public bool RemoveModel(ICampaign model)
        {
            return campaigns.Remove(campaigns.FirstOrDefault(i => i.Brand == model.Brand));
        }

        public ICampaign FindByName(string name)
        {
            return campaigns.FirstOrDefault(i => i.Brand == name);
        }

    }
}

