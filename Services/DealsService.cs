namespace ActiveCampaign.Net.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ActiveCampaign.Net.Models;
    using ActiveCampaign.Net.Models.Deal;

    public class DealsService : ActiveCampaignService
    {
        public DealsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<Deal?> AddDealAsync(Deal deal)
        {
            var jsonResponse = await Send<Deal>("deal_add", deal);
            return jsonResponse;
        }

        public async Task<bool> DeleteDealAsync(int dealId)
        {
            var jsonResponse = await Send<Result>("deal_delete", new { id = dealId });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<Deal?> EditDealAsync(Deal deal)
        {
            var jsonResponse = await Send<Deal>("deal_edit", deal);
            return jsonResponse;
        }

        public async Task<Deal?> GetDealAsync(int dealId)
        {
            var jsonResponse = await Get<Deal>("deal_get", new { id = dealId });
            return jsonResponse;
        }

        public async Task<List<Deal>?> GetAllDealsAsync()
        {
            var jsonResponse = await Get<List<Deal>>("deal_list");
            return jsonResponse;
        }

        public async Task<bool> AddDealNoteAsync(int dealId, string note)
        {
            var jsonResponse = await Send<Result>("deal_note_add", new { deal_id = dealId, note });
            return jsonResponse?.ResultCode == 1;
        }

        public async Task<bool> EditDealNoteAsync(int noteId, string note)
        {
            var jsonResponse = await Send<Result>("deal_note_edit", new { id = noteId, note });
            return jsonResponse?.ResultCode == 1;
        }
    }
}
