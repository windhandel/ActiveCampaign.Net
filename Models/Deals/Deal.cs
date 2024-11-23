namespace ActiveCampaign.Net.Models.Deal
{
    public class Deal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; }
        public int Stage { get; set; }
        public int Owner { get; set; }
    }
}
