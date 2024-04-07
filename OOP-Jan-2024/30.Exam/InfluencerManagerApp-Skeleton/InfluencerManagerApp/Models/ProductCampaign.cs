using System;
namespace InfluencerManagerApp.Models
{
    public class ProductCampaign : Campaign
    {
        private const double Budget = 60000;

        public ProductCampaign(string brand) : base(brand, Budget)
        {
        }


        //todo
        //It can contribute to business and fashion influencers. Keep that in mind for the business logic.

    }
}

