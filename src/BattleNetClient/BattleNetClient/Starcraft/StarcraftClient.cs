using BattleNetClient.Starcraft.Apis;

namespace BattleNetClient.Starcraft
{
    public interface IStarcraftClient
    {
        IProfileApi Profile { get; }
    }

    internal class StarcraftClient : IStarcraftClient
    {
        public IProfileApi Profile { get; }

        public StarcraftClient(Region region)
        {
            Profile = new ProfileApi(region);
        }
    }
}