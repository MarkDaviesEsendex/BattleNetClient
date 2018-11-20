using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BattleNetClient.Diablo;
using BattleNetClient.Diablo.Models;
using BattleNetClient.Testing;
using BattleNetClient.Tests.ClientFactoryTests;
using Newtonsoft.Json;
using Xunit;

namespace BattleNetClient.Tests.Diablo.Acts
{
    public class GetAct
    {
        private readonly BattleNetClientFactory _factory;

        public GetAct()
        {
            var server = new BattleNetServerBuilder()
                .CreateClientCredentials("clientId", "clientSecret")
                .Build();

            _factory = new BattleNetClientFactory(Region.UnitedStates, server.GetClient());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async Task WhenValidActIsRequested_ThenExpectedActIsReturned(int actId, string actString)
        {
            var client = await _factory.CreateClientAsync("clientId", "clientSecret");
            var actualActResult = await client.Diablo.Act.GetByIdAsync(actId);
            var expectedAct = JsonConvert.DeserializeObject<Act>(actString);

            var actualAct = actualActResult.Data;
            Assert.True(actualActResult.IsValid);
            Assert.Equal(HttpStatusCode.OK, actualActResult.Code);
            Assert.Equal(expectedAct.Slug, actualAct.Slug);
            Assert.Equal(expectedAct.Number, actualAct.Number);
            Assert.Equal(expectedAct.Name, actualAct.Name);

            for (var i = 0; i < expectedAct.Quests.Count; i++)
            {
                Assert.Equal(expectedAct.Quests[i].Id, actualAct.Quests[i].Id);
                Assert.Equal(expectedAct.Quests[i].Name, actualAct.Quests[i].Name);
                Assert.Equal(expectedAct.Quests[i].Slug, actualAct.Quests[i].Slug);
            }
        }
        
        [Fact]
        public async Task WhenInvalidActIsRequested_ThenNoActIsReturned()
        {
            var client = await _factory.CreateClientAsync("clientId", "clientSecret");
            var actualActResult = await client.Diablo.Act.GetByIdAsync(52);
            var actualAct = actualActResult.Data;

            Assert.False(actualActResult.IsValid);
            Assert.Equal(HttpStatusCode.NotFound, actualActResult.Code);
            Assert.Empty(actualAct.Slug);
            Assert.Equal(-1, actualAct.Number);
            Assert.Empty(actualAct.Name);
            Assert.Empty(actualAct.Quests);
        }

        public static IEnumerable<object[]> TestData => Data;
        private static readonly List<object[]> Data
            = new List<object[]>
            {
                new object[] {1, "{\"slug\":\"act-i\",\"number\":1,\"name\":\"Act I\",\"quests\":[{\"id\":87700,\"name\":\"The Fallen Star\",\"slug\":\"the-fallen-star\"},{\"id\":72095,\"name\":\"The Legacy of Cain\",\"slug\":\"the-legacy-of-cain\"},{\"id\":72221,\"name\":\"A Shattered Crown\",\"slug\":\"a-shattered-crown\"},{\"id\":72061,\"name\":\"Reign of the Black King\",\"slug\":\"reign-of-the-black-king\"},{\"id\":117779,\"name\":\"Sword of the Stranger\",\"slug\":\"sword-of-the-stranger\"},{\"id\":72738,\"name\":\"The Broken Blade\",\"slug\":\"the-broken-blade\"},{\"id\":73236,\"name\":\"The Doom in Wortham\",\"slug\":\"the-doom-in-wortham\"},{\"id\":72546,\"name\":\"Trailing the Coven\",\"slug\":\"trailing-the-coven\"},{\"id\":72801,\"name\":\"The Imprisoned Angel\",\"slug\":\"the-imprisoned-angel\"},{\"id\":136656,\"name\":\"Return to New Tristram\",\"slug\":\"return-to-new-tristram\"}]}"},
                new object[] {2, "{\"slug\":\"act-ii\",\"number\":2,\"name\":\"Act II\",\"quests\":[{\"id\":80322,\"name\":\"Shadows in the Desert\",\"slug\":\"shadows-in-the-desert\"},{\"id\":93396,\"name\":\"The Road to Alcarnus\",\"slug\":\"the-road-to-alcarnus\"},{\"id\":74128,\"name\":\"City of Blood\",\"slug\":\"city-of-blood\"},{\"id\":57331,\"name\":\"A Royal Audience\",\"slug\":\"a-royal-audience\"},{\"id\":78264,\"name\":\"Unexpected Allies\",\"slug\":\"unexpected-allies\"},{\"id\":78266,\"name\":\"Betrayer of the Horadrim\",\"slug\":\"betrayer-of-the-horadrim\"},{\"id\":57335,\"name\":\"Blood and Sand\",\"slug\":\"blood-and-sand\"},{\"id\":57337,\"name\":\"The Black Soulstone\",\"slug\":\"the-black-soulstone\"},{\"id\":121792,\"name\":\"The Scouring of Caldeum\",\"slug\":\"the-scouring-of-caldeum\"},{\"id\":57339,\"name\":\"Lord of Lies\",\"slug\":\"lord-of-lies\"}]}"},
            };

    }
}