namespace ActiveCampaign.Net.Models
{
    public class Paginator
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
