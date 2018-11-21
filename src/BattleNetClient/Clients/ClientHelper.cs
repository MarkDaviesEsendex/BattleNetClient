using System.Net.Http;

namespace BattleNetClient.Clients
{
    public class ClientHelper
    {
        public ClientHelper(HttpClient client, BattleNetRegion battleNetRegion)
        {
            Client = client;
            BattleNetRegion = battleNetRegion;
        }

        public HttpClient Client { get; }
        public BattleNetRegion BattleNetRegion { get; }
    }
}