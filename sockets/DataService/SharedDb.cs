using sockets.Models;
using System.Collections.Concurrent;

namespace sockets.DataService
{
    public class SharedDb
    {
        private readonly ConcurrentDictionary<string, long> _connections = new ConcurrentDictionary<string, long>();

        public ConcurrentDictionary<string, long> connections => _connections;
    }
}
