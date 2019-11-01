using Newtonsoft.Json;
using PokemonGo.BaseStats.Service.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGo.BaseStats.Service.Services
{
    public class PokemonBaseStatAPI : PokemonBaseStatService
    {
        private static HttpClient Client = new HttpClient();
        private string _apiUrl;
        private string _apiHost;
        private string _apiKey;

        public PokemonBaseStatAPI(string url, string rapidHost, string apiKey)
            : base()
        {
            _apiUrl = url;
            _apiHost = rapidHost;
            _apiKey = apiKey;
        }


        public override async Task CheckCache()
        {
            if (BaseStatCache.Count == 0  // No cache at all
                || (DateTime.Now - LastCacheTime).TotalDays >= 1) // It's been longer than one day
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, new Uri(_apiUrl));
                    // Set them headers
                    request.Headers.Add("X-RapidAPI-Host", _apiHost);
                    request.Headers.Add("x-rapidapi-key", _apiKey);

                    var result = await Client.SendAsync(request);

                    // Did we get a good status code?
                    result.EnsureSuccessStatusCode();

                    // Grab the contents
                    string responseBody = await result.Content.ReadAsStringAsync();

                    // Try an parse the response into our cache, boiz.
                    BaseStatCache = JsonConvert.DeserializeObject<List<PokemonBaseStats>>(responseBody);
                    LastCacheTime = DateTime.Now;
                }
                catch (Exception ex)
                {
                    // TODO: Logging
                    throw;
                }
            }
        }
    }
}
