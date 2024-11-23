namespace ActiveCampaign.Net.Models.Contact
{
    public class ContactAutomation
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int AutomationId { get; set; }
        public string Status { get; set; }
    }
}
