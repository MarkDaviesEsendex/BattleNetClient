using BattleNetClient.Starcraft.Response;

namespace BattleNetClient.Tests.Starcraft.Profile
{
    public class XelxRanderInformation : IProfileInformation
    {
        public int PlayerId => 4414793;
        public int Region => 1;
        public string PlayerName => "XelxRander";

        public IStarcraftProfile ExpectedProfile => new StarcraftProfile
        {
            Id = 4414793,
            Realm = 1,
            ClanName = "",
            ClanTag = "",
            DisplayName = "XelxRandar",
            ProfilePath = "/profile/4414793/1/XelxRandar/"
        };
    }
}