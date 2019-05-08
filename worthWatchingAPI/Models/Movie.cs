using System;

namespace worthWatchingAPI.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string PosterImage { get; set; }
        public decimal? IMDBRating { get; set; }
        public int? RTRating { get; set; }
        public int? MetacriticRating { get; set; }
    }
}