using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using worthWatchingAPI.Models;

namespace worthWatchingAPI.Connectors
{
    public interface IOMDBConnector
    {
        Task<JObject> GetMovie(string title);
        //Task<LinkedList<JObject>> GetMovies(List<string> titles, string apikey);
    }
}