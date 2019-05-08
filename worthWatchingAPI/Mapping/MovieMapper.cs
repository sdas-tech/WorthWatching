using Newtonsoft.Json.Linq;
using worthWatchingAPI.Models;

namespace worthWatchingAPI.Mapping
{
    public class MovieMapper
    {
        public Movie JsonToMovie(JObject json)
        {
            if (json.SelectToken("Title") != null)
            {
                //do the mapping
                var movieDetails = new Movie  
                {  
                    Title = json.SelectToken("Title").Value<string>(),
                    ReleaseDate = json.SelectToken("Year").Value<string>(),  
                    IMDBRating = json.SelectToken("imdbRating").Value<decimal>(),
                    RTRating = json.TryGetValue(),
                    MetacriticRating = json.SelectToken("Metascore").Value<int>(),
                    PosterImage = json.SelectToken("Poster").Value<string>() 
                };
                
                return movieDetails;
            }
            else
            {
                throw new System.Exception("Error when deserialising movie, title was null");
            }
            return null;
        }
    }
}