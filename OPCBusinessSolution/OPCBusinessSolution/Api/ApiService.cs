using Microsoft.AspNetCore.Mvc.Routing;
using System.Web;

namespace OPCBusinessSolution.Api
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiOPCBS");
        }

        public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> queryParams = null)
        {
            string url = endpoint;
            if (queryParams != null)
            {
                url = UrlHelper.AddQueryParameters(endpoint, queryParams);
            }
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<T>();
            return data;
        }
    }


    public static class UrlHelper
    {
        public static string AddQueryParameters(string url, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var param in queryParams)
            {
                query[param.Key] = param.Value;
            }
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }
    }
}
