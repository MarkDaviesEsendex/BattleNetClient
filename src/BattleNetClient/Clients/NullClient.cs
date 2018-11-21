using BattleNetClient.Diablo;

namespace BattleNetClient.Clients
{
    internal class NullClient : IBattleNetClient
    {
        public NullClient() 
            => Diablo = new NullDiabloClient();

        public IDiabloClient Diablo { get; }
        public bool IsClientValid => false;
    }
}