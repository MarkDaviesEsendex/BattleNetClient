using BattleNetClient.Starcraft;

namespace BattleNetClient
{
    public interface IBattleNetClient
    {
        IStarcraftClient Starcraft { get; }
    }

    internal class BattleNetClient : IBattleNetClient
    {
        public IStarcraftClient Starcraft { get; }

        public BattleNetClient(Region region)
        {
            Starcraft = new StarcraftClient(region);
        }
    }
}
