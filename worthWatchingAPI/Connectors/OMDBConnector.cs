using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using worthWatchingAPI.Models;

namespace worthWatchingAPI.Connectors
{
    public class OMDBConnector : IOMDBConnector
    {
        private readonly HttpClient _client;
    
        public OMDBConnector(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://www.omdbapi.com");
            // httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            // httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = httpClient;
        }

        
        public async Task<JObject> GetMovie(string title, string apiKey)
        {
            JObject json;

            try{
                var response = await _client.GetStringAsync($"/?t={title}&apikey={apiKey}");
                json = JObject.Parse(response);
            }
            catch (Exception e)
            {
                throw new Exception($"Error when getting movie: {title}", e);
            }

            return json;
        }

        //converts from dd Mmm yyyy format
        // private DateTime ToMovieReleaseDate(string date)
        // {
        //     string pattern = "dd MMM yyyy";
        //     if (DateTime.TryParseExact(date, pattern, null, DateTimeStyles.None, out var parsedDate))
        //     {
        //         return parsedDate;
        //     }
        //     else {
        //         throw new InvalidCastException();
        //     }
        // }
    }
}