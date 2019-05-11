namespace worthWatchingAPI.Models
{
    public class ReturnMovie
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public decimal? IMDBRating { get; set; }
        public int? RTRating { get; set; }
        public int? MetacriticRating { get; set; }
        public string PosterImage { get; set; }
    }
}