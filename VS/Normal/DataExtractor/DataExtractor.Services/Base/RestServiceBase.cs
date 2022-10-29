using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataExtractor.Services.Base
{
    public class RestServiceBase
    {
        private HttpClient _httpClient;

        protected RestServiceBase()
        {
            _httpClient = new HttpClient();
        }

        protected void SetBaseURL(string appBaseUri)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Brotli,
            };
            _httpClient = new(httpClientHandler)
            {
                BaseAddress = new Uri(appBaseUri),
                Timeout = TimeSpan.FromMilliseconds(6000000)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")            
             );
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding","gzip, deflate, br");            
        }

        protected void AddHttpHeader(string key, string value) =>
            _httpClient.DefaultRequestHeaders.Add(key, value);

        protected async Task<T> GetAsync<T>(string resource)
        {
            //Get Json data (from Cache or Web)
            var json = await GetJsonAsync(resource);

            //Return the result
            return JsonSerializer.Deserialize<T>(json);
        }

        private async Task<string> GetJsonAsync(string resource)
        { 
            //Extract response from URI
            var response = await _httpClient.GetAsync(new Uri(_httpClient.BaseAddress, resource));

            //Check for valid response
            response.EnsureSuccessStatusCode();

            //Read Response
            string json = await response.Content.ReadAsStringAsync(); 
           
            //Return the result
            return json;
        }

        protected async Task<HttpResponseMessage> PostAsync<T>(string uri, T payload)
        {
            var dataToPost = JsonSerializer.Serialize(payload);
            var content = new StringContent(dataToPost, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(_httpClient.BaseAddress, uri), content);

            response.EnsureSuccessStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> PutAsync<T>(string uri, T payload)
        {
            var dataToPost = JsonSerializer.Serialize(payload);
            var content = new StringContent(dataToPost, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(new Uri(_httpClient.BaseAddress, uri), content);

            response.EnsureSuccessStatusCode();

            return response;
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(new Uri(_httpClient.BaseAddress, uri));

            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
