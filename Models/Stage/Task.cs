namespace ActiveCampaign.Net.Models.Deal
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DealId { get; set; }
        public int Type { get; set; }
        public DateTime DueDate { get; set; }
    }
}
