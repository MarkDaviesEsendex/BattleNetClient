namespace BattleNetClient
{
    public class BattleNetClientFactory
    {
        private readonly string _apiKey;

        public BattleNetClientFactory(string apiKey) 
            => _apiKey = apiKey;

        public IBattleNetClient CreateRegionalClient(Region region)
            => new BattleNetClient(region);

    }
}