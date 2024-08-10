namespace InfluencerManagerApp.Models.CampaignChild
{
    public class ProductCampaign :Campaign
    {
        private const double PCBudget = 60_000;
        public ProductCampaign(string brand) 
            : base(brand, PCBudget)
        {
        }
    }
}
