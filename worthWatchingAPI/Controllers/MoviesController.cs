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
        [Produces("application/json")]
        public async Task<Movie> GetAsync()
        {
            var title = "something";

            var response = await _OMDBConnector.GetMovie(title);
            return response;
        }

        // GET api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
