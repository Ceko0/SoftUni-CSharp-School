namespace InfluencerManagerApp.Models.InfluencerChild
{

    public class FashionInfluencer : Influencer
    {
        private const double FIEngagementRate = 4.0;
        private const double FIFactor = 0.1;

        public FashionInfluencer(string username, int followers)
            : base(username, followers, FIEngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)(base.CalculateCampaignPrice() * FIFactor);
        }
    }
}
