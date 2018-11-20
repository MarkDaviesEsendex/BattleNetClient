using BattleNetClient.Diablo;

namespace BattleNetClient.Clients
{
    internal class BattleNetClient : IBattleNetClient
    {
        public IDiabloClient Diablo { get; }

        public bool IsClientValid => true;

        public BattleNetClient(IDiabloClient diabloClient)
        {
            Diablo = diabloClient;
        }
    }
}
