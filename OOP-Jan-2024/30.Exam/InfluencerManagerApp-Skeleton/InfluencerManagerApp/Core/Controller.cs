using System;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {

        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        //ok
        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != nameof(BusinessInfluencer)
                && typeName != nameof(FashionInfluencer)
                && typeName != nameof(BloggerInfluencer))
            {
                return $"{typeName} has not passed validation.";
            }

            IInfluencer existInfluencer = influencers.FindByName(username);

            if (existInfluencer != null)
            {
                return $"{username} is already registered in InfluencerRepository.";//todo check 
            }

            IInfluencer newInfluencer = null;

            if (typeName == nameof(BusinessInfluencer))
            {
                newInfluencer = new BusinessInfluencer(username, followers);
            }

            else if (typeName == nameof(FashionInfluencer))
            {
                newInfluencer = new FashionInfluencer(username, followers);
            }

            else if (typeName == nameof(BloggerInfluencer))
            {
                newInfluencer = new BloggerInfluencer(username, followers);
            }

            influencers.AddModel(newInfluencer);

            return $"{username} registered successfully to the application.";

        }

        //ok
        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != nameof(ProductCampaign)
                && typeName != nameof(ServiceCampaign))
            {
                return $"{typeName} is not a valid campaign in the application.";
            }

            ICampaign existexistingCampaign = campaigns.FindByName(brand);

            if (existexistingCampaign != null)
            {
                return $"{brand} campaign cannot be duplicated.";
            }


            ICampaign newCampaign = null;

            if (typeName == nameof(ProductCampaign))
            {
                newCampaign = new ProductCampaign(brand);
            }

            if (typeName == nameof(ServiceCampaign))
            {
                newCampaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(newCampaign);

            return $"{brand} started a {typeName}.";
        }

        //working...
        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer existInfluencer = influencers.FindByName(username);
            ICampaign existCampaign = campaigns.FindByName(brand);

            if (existInfluencer == null)
            {
                return $"{existCampaign.GetType().Name} has no {username} registered in the application.";// problem
            }

            if (existCampaign == null)
            {
                return $"There is no campaign from {brand} in the application.";
            }

            if (existCampaign.Contributors != existInfluencer)
            {
                return $"{username} is already engaged for the {brand} campaign.";
            }

            //todo
            //It can contribute to business and fashion influencers. Keep that in mind for the business logic.


            if (existCampaign.GetType().Name == "ProductCampaign")
            {
                if (existInfluencer.GetType().Name != "BusinessInfluencer" && existInfluencer.GetType().Name != "FashionInfluencer")
                {
                    return $"{username} is not eligible for the {brand} campaign.";
                }

            }
            else if (existCampaign.GetType().Name == "ServiceCampaign")
            {
                if (existInfluencer.GetType().Name != "BusinessInfluencer" && existInfluencer.GetType().Name != "BloggerInfluencer")
                {
                    return $"{username} is not eligible for the {brand} campaign.";
                }
            }

            if (existCampaign.Budget < existInfluencer.EngagementRate)
            {
                return $"The budget for {brand} is insufficient to engage {username}.";
            }

            existCampaign.Engage(existInfluencer);
            return $"{username} has been successfully attracted to the {brand} campaign.";

        }

        public string ApplicationReport()
        {
            throw new NotImplementedException();
        }

        public string FundCampaign(string brand, double amount)
        {

            if (amount < 0)
            {
                return $"Funding amount must be greater than zero.";
            }

            ICampaign existCampaign = campaigns.FindByName(brand);
            existCampaign.Gain(amount);


            return $"{brand} campaign has been successfully funded with {amount} $";
        }



        public string CloseCampaign(string brand)
        {
            throw new NotImplementedException();
        }

        public string ConcludeAppContract(string username)
        {
            throw new NotImplementedException();
        }

        


    }
}

