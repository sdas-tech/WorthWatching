using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using worthWatchingAPI.Connectors;
using worthWatchingAPI.Models;
using worthWatchingAPI.Orchestrators;

namespace worthWatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public readonly MovieOrchestrator _movieOrchestrator;

        public MoviesController(MovieOrchestrator movieOrchestrator)
        {
            _movieOrchestrator = movieOrchestrator;
        }

        // GET api/Movies/5
        [HttpGet("{title}")]
        public async Task<ReturnMovie> GetSingleMovie(string title)
        {
            var response = await _movieOrchestrator.GetMovie(title);
            return response;
        }

        // POST api/Movies
        [HttpPost]
        public async Task<LinkedList<ReturnMovie>> GetListOfMovies([FromBody] List<string> titles)
        {
            var response = await _movieOrchestrator.GetMovies(titles);
            return response;
        }
    }
}
