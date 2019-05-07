using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using worthWatchingAPI.Connectors;
using worthWatchingAPI.Mapping;
using worthWatchingAPI.Models;

namespace worthWatchingAPI.Orchestrators
{
    public class MovieOrchestrator
    {
        private readonly IOMDBConnector _OMDBConnector;
        private readonly MovieMapper _movieMapper;
        private readonly IConfiguration _configuration;

        public MovieOrchestrator(IOMDBConnector OMDBConnector, MovieMapper movieMapper)
        {
            _OMDBConnector = OMDBConnector;
            _movieMapper = movieMapper;
        }

        public async Task<Movie> GetMovie(string title)
        {
            //Get movie from OMDB
            JObject backendResponse = await _OMDBConnector.GetMovie(title, "3d51a22a"); //todo: get api key from configuration
            //Do some verification (TODO)
            //Map the JSON to a Movie object
            Movie mappedMovie = _movieMapper.JsonToMovie(backendResponse);

            return mappedMovie;
        }

        public async Task<LinkedList<Movie>> GetMovies(List<string> titles)
        {
            LinkedList<JObject> backendResponses = new LinkedList<JObject>();
            LinkedList<Movie> movieList = new LinkedList<Movie>();

            //todo: make this fancy async
            foreach (var movie in titles)
            {
                backendResponses.AddLast(await _OMDBConnector.GetMovie(movie, "3d51a22a")); //todo: get api key from configuration
            }
            foreach (JObject jobject in backendResponses)
            {
                movieList.AddLast(_movieMapper.JsonToMovie(jobject));
            }

            return movieList;
        }
    }
}