namespace ActiveCampaign.Net.Models.Webhook
{
    public class Webhook
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public List<string> Events { get; set; } = new List<string>();
    }
}
