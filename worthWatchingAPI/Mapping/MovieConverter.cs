using System;
using System.Linq;
using worthWatchingAPI.Models;
using worthWatchingAPI.ExtensionMethods;

namespace worthWatchingAPI.Mapping
{
    public class MovieConverter
    {
        public ReturnMovie OMDBToReturnMovie(OMDBMovie omdb)
        {
            return new ReturnMovie() {
                Title = omdb.Title,
                ReleaseDate = omdb.Released,
                IMDBRating = ToDecimal(omdb.Ratings.Where(x => x.Source == "Internet Movie Database")?.LastOrDefault()?.Value?.TrimNumFromEnd(3)),
                RTRating = ToInt(omdb.Ratings.Where(x => x.Source == "Rotten Tomatoes")?.LastOrDefault()?.Value?.TrimEnd('%')),
                MetacriticRating = ToInt(omdb.Ratings.Where(x => x.Source == "Metacritic")?.LastOrDefault()?.Value?.TrimNumFromEnd(4)),
                PosterImage = omdb.Poster
            };
        }

        private int? ToInt(string intstring)
        {
            if (String.IsNullOrWhiteSpace(intstring))
            {
                return null;
            }
            else if (int.TryParse(intstring, out var convertedint))
            {
                return convertedint;
            }
            else
            {
                return null;
            }
        }

        private decimal? ToDecimal(string decimalstring)
        {
            if (String.IsNullOrWhiteSpace(decimalstring))
            {
                return null;
            }
            else if (decimal.TryParse(decimalstring, out var converteddecimal))
            {
                return converteddecimal;
            }
            else
            {
                return null;
            }
        }


    }
}

                //     Title = json.SelectToken("Title").Value<string>(),
                //     ReleaseDate = json.SelectToken("Year").Value<string>(),  
                //     IMDBRating = json.SelectToken("imdbRating").Value<decimal>(),
                //     RTRating = 0,
                //     MetacriticRating = json.SelectToken("Metascore").Value<int>(),
                //     PosterImage = json.SelectToken("Poster").Value<string>() 