using BattleNetClient.Diablo;

namespace BattleNetClient.Clients
{
    public interface IBattleNetClient
    {
        IDiabloClient Diablo { get; }
        
        bool IsClientValid { get; }
    }
}