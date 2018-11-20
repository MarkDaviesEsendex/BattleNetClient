using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace BattleNetClient.Testing
{
    public class BattleNetServerBuilder
    {
        private readonly IBattleNetServer _server;

        public BattleNetServerBuilder() 
            => _server = new BattleNetServer();

        public BattleNetServerBuilder CreateClientCredentials(string clientId, string clientSecret)
        {
            Task.Run(async () =>
            {
                await _server.GetClient().PostAsync("/oauth/clientInfo", new {clientId, clientSecret},
                    new JsonMediaTypeFormatter());
            }).Wait();
            return this;
        }

        public IBattleNetServer Build() 
            => _server;
    }
}