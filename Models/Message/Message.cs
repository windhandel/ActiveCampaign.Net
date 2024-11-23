namespace ActiveCampaign.Net.Models.Message
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ReplyTo { get; set; }
        public string HtmlContent { get; set; }
        public string TextContent { get; set; }
    }
}
