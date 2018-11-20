using System.Net.Http;

namespace BattleNetClient.Clients
{
    public class ClientHelper
    {
        public ClientHelper(HttpClient client, Region region)
        {
            Client = client;
            Region = region;
        }

        public HttpClient Client { get; }
        public Region Region { get; }
    }
}