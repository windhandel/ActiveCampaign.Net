namespace ActiveCampaign.Net.Models.Campaign
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public CampaignStatus Status { get; set; }
    }

    public enum CampaignStatus
    {
        Draft = 1,
        Sent = 2,
        Scheduled = 3
    }
}
