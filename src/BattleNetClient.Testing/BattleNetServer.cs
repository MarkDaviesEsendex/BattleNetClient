using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace BattleNetClient.Testing
{
    public interface IBattleNetServer
    {
        HttpClient GetClient();
        string[] GetRequests();
    }

    internal class BattleNetServer : IBattleNetServer
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public BattleNetServer()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public HttpClient GetClient() 
            => _client;

        public string[] GetRequests() 
            => new string[0];
    }
}
