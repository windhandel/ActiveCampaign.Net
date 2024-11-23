namespace ActiveCampaign.Net.Services
{
    using ActiveCampaign.Net.Models.User;

    public class ClientService : ActiveCampaignService
    {
        public ClientService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        /// <summary>
        /// Retrieve info about client
        /// </summary>
        /// <returns></returns>
        public async Task<UserInfoResponse?> ClientMe()
        {
            var userInfoResponse = await Get<UserInfoResponse>("client_me");

            return userInfoResponse;
        }
    }
}
