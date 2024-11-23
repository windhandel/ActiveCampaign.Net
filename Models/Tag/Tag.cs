namespace ActiveCampaign.Net.Models.Tag
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; } = string.Empty;
        public string? TagType { get; set; }
        public string? Description { get; set; }
    }
}
