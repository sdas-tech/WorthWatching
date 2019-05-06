using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using worthWatchingAPI.Modles;

namespace worthWatchingAPI.Connectors
{
    public class OMDBConnector : IOMDBConnector
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
    
        public OMDBConnector(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://www.omdbapi.com");
            // httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            // httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _apiKey = "3d51a22a";
            _client = httpClient;
        }

        public async Task<Movie> GetMovie(string title)
        {
            var response = await _client.GetStringAsync($"/?t={title}&apikey={_apiKey}");
            JObject json = JObject.Parse(response);

            if (json.SelectToken("Title") != null)
            {
                //do the mapping
                var movieDetails = new Movie  
                {  
                    Title = json.SelectToken("Title").Value<string>(),  
                    ReleaseDate = ToMovieReleaseDate(json.SelectToken("Year").Value<string>()),  
                    IMDBRating = json.SelectToken("imdbRating").Value<decimal>(),
                    RTRating = 6,
                    MetacriticRating = json.SelectToken("Metascore").Value<int>(),
                    PosterImage = json.SelectToken("Poster").Value<string>() 
                };

                return movieDetails;
            }
            return null;
        }

        //converts from dd Mmm yyyy format
        private DateTime ToMovieReleaseDate(string date)
        {
            string pattern = "dd MMM yyyy";
            if (DateTime.TryParseExact(date, pattern, null, DateTimeStyles.None, out var parsedDate))
            {
                return parsedDate;
            }
            else {
                throw new InvalidCastException();
            }
        }
    }
}