using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using worthWatchingAPI.Connectors;
using worthWatchingAPI.Modles;

namespace worthWatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public readonly IOMDBConnector _OMDBConnector;

        public MoviesController(IOMDBConnector OMDBConnector)
        {
            _OMDBConnector = OMDBConnector;
        }
        
        // GET api/Movies
        [HttpGet]
        public async Task<List<Movie>> GetMovies()
        {
            var title = "something";
            var response = await _OMDBConnector.GetMovie(title);
            return new List<Movie>(){response};
        }

        // GET api/Movies/5
        [HttpGet("{title}")]
        public async Task<Movie> GetSingleMovie(string title)
        {
            var response = await _OMDBConnector.GetMovie(title);
            return response;
        }

        // POST api/Movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
