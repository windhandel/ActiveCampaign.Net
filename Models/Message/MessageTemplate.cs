namespace ActiveCampaign.Net.Models.Message
{
    public class MessageTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string HtmlContent { get; set; }
        public string TextContent { get; set; }
    }
}
