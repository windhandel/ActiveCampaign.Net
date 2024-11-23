using ActiveCampaign.Net.Models;
using ActiveCampaign.Net.Models.Account;

namespace ActiveCampaign.Net.Services
{
    public class AccountService : ActiveCampaignService
    {
        public AccountService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        /// <summary>
        /// Add a new account, just like you would on the Manage Accounts page of the reseller panel.
        /// </summary>
        /// <param name="model">AccountModel</param>
        /// <returns>Task<AccountAddResponse></returns>
        public async Task<AccountAddResponse?> AccountAddAsync(AccountAdd model)
        {
            var jsonResponse = await Send<AccountAddResponse>("account_add", model);
            return jsonResponse;
        }

        /// <summary>
        /// Allows you to cancel an active and payed account.
        /// </summary>
        /// <param name="accountName">account name that you wish to cancel. Example: account.activehosted.com</param>
        /// <param name="reason">reason for cancelling the account</param>
        /// <returns>Task<Result></returns>
        public async Task<Result?> AccountCancelAsync(string accountName, string reason)
        {
            var jsonResponse = await Send<Result>("account_cancel", new { account = accountName, reason });
            return jsonResponse;
        }

        /// <summary>
        /// View multiple accounts under your reseller profile including all information associated with each
        /// </summary>
        /// <param name="search"></param>
        /// <returns>Task<AccountListResponse></returns>
        public async Task<AccountListResponse?> AccountListAsync(string? search = null)
        {
            var jsonResponse = await Get<AccountListResponse>("account_list", new { search });
            return jsonResponse;
        }

        /// <summary>
        /// Allows you to retrieve a list of currently available plans for an account.
        /// </summary>
        /// <param name="accountName">account name that you wish to check the plans for. Leave empty to get default plans.</param>
        /// <returns>Task<Result></returns>
        public async Task<Result?> AccountNameCheckAsync(string accountName)
        {
            var jsonResponse = await Get<Result>("account_name_check", new { account = accountName });
            return jsonResponse;
        }

        /// <summary>
        /// Allows you to retrieve a list of currently available plans for an account.
        /// </summary>
        /// <param name="accountName">full account name that you wish to check the plans for. Leave empty to get default plans.</param>
        /// <returns>Task<AccountPlansResponse></returns>
        public async Task<AccountPlansResponse?> AccountPlansAsync(string? accountName = null)
        {
            var jsonResponse = await Get<AccountPlansResponse>("account_plans", new { account = accountName });
            return jsonResponse;
        }

        /// <summary>
        /// Allows you to check the account status. Possible results are active, disabled, creating, cancelled.
        /// </summary>
        /// <param name="accountName">account name that you wish to check. ".activehosted.com" will be appended for you</param>
        /// <returns>Task<AccountStatusResponse></returns>
        public async Task<AccountStatusResponse?> AccountStatusAsync(string accountName)
        {
            var jsonResponse = await Get<AccountStatusResponse>("account_status", new { account = accountName });
            return jsonResponse;
        }
    }
}
