namespace ActiveCampaign.Net.Models.Segment
{
    public class Segment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Filter { get; set; }
    }
}
