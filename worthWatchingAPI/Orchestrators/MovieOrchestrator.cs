using System;
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
        private readonly MovieConverter _movieConverter;

        public MovieOrchestrator(IOMDBConnector OMDBConnector, MovieMapper movieMapper, MovieConverter movieConverter)
        {
            _OMDBConnector = OMDBConnector;
            _movieMapper = movieMapper;
            _movieConverter = movieConverter;
        }

        public async Task<ReturnMovie> GetMovie(string title)
        {
            //Get movie from OMDB
            JObject backendResponse = await _OMDBConnector.GetMovie(title);
            //Do some verification (TODO)
            //Map the JSON to a Movie object
            if (backendResponse != null)
            {
                OMDBMovie mappedMovie = _movieMapper.JsonToMovie(backendResponse);
                ReturnMovie returnMovie = _movieConverter.OMDBToReturnMovie(mappedMovie);
                return returnMovie;
            }
            else
            {
                //todo make exceptions return prpper json errors
                throw new Exception($"Could not retrieve movie {title}");
            }

        }

        public async Task<LinkedList<ReturnMovie>> GetMovies(List<string> titles)
        {
            LinkedList<JObject> backendResponses = new LinkedList<JObject>();
            LinkedList<ReturnMovie> movieList = new LinkedList<ReturnMovie>();

            //todo: make this fancy async
            foreach (var movie in titles)
            {
                try
                {
                    JObject singleResponse = await _OMDBConnector.GetMovie(movie);
                    if (singleResponse != null)
                    {
                        backendResponses.AddLast(singleResponse);
                    }
                    else
                    {
                        Console.WriteLine($"Error when trying to retrieve {movie}, skipping adding it to the list");
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }
            foreach (JObject jobject in backendResponses)
            {
                //movieList.AddLast(_movieMapper.JsonToMovie(jobject));
            }

            return movieList;
        }
    }
}