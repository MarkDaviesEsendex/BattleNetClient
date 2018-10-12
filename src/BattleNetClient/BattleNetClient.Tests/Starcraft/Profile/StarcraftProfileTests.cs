using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BattleNetClient.Tests.Starcraft.Profile
{
    public class StarcraftProfileTests
    {
        public static IEnumerable<object[]> ProfileData()
        {
            yield return new object[] {new XelxRanderInformation()};
        }

        [Theory]
        [MemberData(nameof(ProfileData))]
        public async Task WhenProfileExists_ThenCorrectInformationIsRetrieved(IProfileInformation playerInfo)
        {
            var battleNetClientFactory = new BattleNetClientFactory("key");
            var client = battleNetClientFactory.CreateRegionalClient(Region.Us).Starcraft.Profile;
            var profile =
                await client.GetAsync(playerInfo.PlayerId, playerInfo.Region, playerInfo.PlayerName);
            Assert.NotStrictEqual(playerInfo.ExpectedProfile, profile);
        }
    }
}
