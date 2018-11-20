namespace BattleNetClient.Diablo
{
    internal class NullDiabloClient : IDiabloClient
    {
        public NullDiabloClient() 
            => Act = new NullActClient();

        public IActClient Act { get; }
    }
}