using System.Reflection;
using System.Text;
using System.Web;
using ActiveCampaign.Net.Models;
using Newtonsoft.Json;

namespace ActiveCampaign.Net.Services
{
    public abstract class ActiveCampaignService
    {
        public const string HttpClientName = "ActiveCampaignHttpClient";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private static readonly Dictionary<Type, PropertyInfo[]> PropertyCache = new();
        private static readonly ReaderWriterLockSlim CacheLock = new();

        protected ActiveCampaignService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient(HttpClientName);
        }

        protected async Task<TModel?> Get<TModel>(string action, object? model = null)
        {
            var getParameters = model != null ? ConvertToDictionary(model) : null;
            var url = BuildUrl(action, getParameters);
            var response = await _httpClient.GetAsync(url);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TModel>(jsonResponse);
        }

        protected async Task<TModel?> Send<TModel>(string action, object model)
        {
            var postData = ConvertToDictionary(model);
            var content = new FormUrlEncodedContent(postData);
            var response = await _httpClient.PostAsync(action, content);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TModel>(jsonResponse);
        }

        protected bool IsRequestSuccessfull(Result response)
        {
            return response.ResultCode == 1;
        }

        private string BuildUrl(string action, Dictionary<string, string>? parameters)
        {
            var url = action;
            if (parameters != null && parameters.Count > 0)
            {
                var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={HttpUtility.UrlEncode(p.Value)}"));
                url = $"{action}?{queryString}";
            }
            return url;
        }

        private Dictionary<string, string> ConvertToDictionary(object model)
        {
            var dictionary = new Dictionary<string, string>();
            var properties = GetProperties(model.GetType());

            foreach (var property in properties)
            {
                var value = property.GetValue(model);
                if (value != null)
                {
                    dictionary.Add(property.Name.ToLower(), value.ToString());
                }
            }
            return dictionary;
        }

        private PropertyInfo[] GetProperties(Type type)
        {
            CacheLock.EnterUpgradeableReadLock();
            try
            {
                if (!PropertyCache.TryGetValue(type, out var properties))
                {
                    CacheLock.EnterWriteLock();
                    try
                    {
                        if (!PropertyCache.TryGetValue(type, out properties))
                        {
                            properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                            PropertyCache[type] = properties;
                        }
                    }
                    finally
                    {
                        CacheLock.ExitWriteLock();
                    }
                }
                return properties;
            }
            finally
            {
                CacheLock.ExitUpgradeableReadLock();
            }
        }
    }
}