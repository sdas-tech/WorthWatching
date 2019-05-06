using System.Threading.Tasks;
using worthWatchingAPI.Modles;

namespace worthWatchingAPI.Connectors
{
    public interface IOMDBConnector
    {
         Task<Movie> GetMovie(string title);
    }
}