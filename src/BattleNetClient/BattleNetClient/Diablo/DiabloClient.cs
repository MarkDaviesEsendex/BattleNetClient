namespace BattleNetClient.Diablo
{
    public interface IDiabloClient
    {
        IActClient Act { get; }
    }
    
    internal class DiabloClient : IDiabloClient
    {
        public IActClient Act { get; }

        public DiabloClient(IActClient actClient)
        {
            Act = actClient;
        }
    }
}
