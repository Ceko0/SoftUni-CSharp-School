namespace InfluencerManagerApp.Models.CampaignChild
{
    public class ServiceCampaign : Campaign
    {
        private const double SCBudget = 30_000;
        public ServiceCampaign(string brand) 
            : base(brand, SCBudget)
        {
        }
    }
}
