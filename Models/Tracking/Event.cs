namespace ActiveCampaign.Net.Models.Tracking
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class Site
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? Status { get; set; }
    }
}
