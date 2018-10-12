using BattleNetClient.Starcraft.Response;

namespace BattleNetClient.Tests.Starcraft.Profile
{
    public interface IProfileInformation
    {
        int PlayerId { get; }
        int Region { get; }
        string PlayerName { get; }
        IStarcraftProfile ExpectedProfile { get; }
    }
}