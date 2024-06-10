using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<string?> GetAsync(string endpoint, Dictionary<string, string> queryParams = null)
        {
            string url = endpoint;
            if (queryParams != null)
            {
                url = UrlHelper.AddQueryParameters(endpoint, queryParams);
            }

            try
            {
                var response = await _httpClient.GetAsync(_httpClient.BaseAddress + url);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return "404";
                }

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
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
