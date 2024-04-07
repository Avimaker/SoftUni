using System;
namespace InfluencerManagerApp.Models
{
	public class ServiceCampaign : Campaign
	{
        private const double Budget = 30000;

        public ServiceCampaign(string brand) : base(brand, Budget)
        {
        }

        //todo
        //It can contribute to business and blogger influencers. Keep that in mind for the business logic.
    }
}

