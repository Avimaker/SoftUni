﻿using InfluencerManagerApp.Core;
using InfluencerManagerApp.Core.Contracts;

namespace InfluencerManagerApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}


/*
RegisterInfluencer FashionInfluencer AlexFas_33 20000
RegisterInfluencer BusinessInfluencer Tech#Guru 30000
RegisterInfluencer BloggerInfluencer TravelVirtu 25000
RegisterInfluencer BusinessInfluencer MarketPPMaven 50000
RegisterInfluencer FashionInfluencer StyleIcon 15000
RegisterInfluencer ReligionInfluencer NoahRivers 150000
RegisterInfluencer BusinessInfluencer TravelVirtu 35000
BeginCampaign ProductCampaign Nike
BeginCampaign ServiceCampaign FoodPanda
BeginCampaign ServiceCampaign Nike
BeginCampaign ProductCampaign Sony
BeginCampaign ServiceCampaign Uber
BeginCampaign HolidayCampaign Traveloka
BeginCampaign ServiceCampaign BookIt
AttractInfluencer Nike NotEX_infl
AttractInfluencer TitanTech Tech#Guru
AttractInfluencer Nike TravelVirtu
AttractInfluencer Nike AlexFas_33
AttractInfluencer Uber TravelVirtu
AttractInfluencer Uber MarketPPMaven
AttractInfluencer Uber Tech#Guru
AttractInfluencer BookIt MarketPPMaven
AttractInfluencer FoodPanda StyleIcon
FundCampaign Uber 20000
FundCampaign Traveloka 10000
FundCampaign BookIt -5000
CloseCampaign Traveloka
CloseCampaign Sony
CloseCampaign Nike
AttractInfluencer Uber MarketPPMaven
AttractInfluencer Uber MarketPPMaven
CloseCampaign Uber
ConcludeAppContract StyleIcon
ConcludeAppContract MarketPPMaven
ConcludeAppContract NoahRivers
ApplicationReport
Exit

 
 
*/