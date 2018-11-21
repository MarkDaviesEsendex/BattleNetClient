using System.Net;
using System.Threading.Tasks;
using BattleNetClient.Diablo.Models;
using BattleNetClient.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BattleNetClient.Tests.Diablo.Acts
{
    public class GetAllActs
    {
        private readonly BattleNetClientFactory _factory;

        public GetAllActs()
        {
            var server = new BattleNetServerBuilder()
                .CreateClientCredentials("clientId", "clientSecret")
                .Build();

            _factory = new BattleNetClientFactory(BattleNetRegion.UnitedStates, server.GetClient());
        }

        [Fact]
        public async Task WhenValidActIsRequested_ThenExpectedActIsReturned()
        {
            var client = await _factory.CreateClientAsync("clientId", "clientSecret");
            var actualActResult = await client.Diablo.Act.GetAllAsync();
            var expectedActs = JsonConvert.DeserializeObject<ActCollection>(
                    "{\"acts\":[{\"slug\":\"act-i\",\"number\":1,\"name\":\"Act I\",\"quests\":[{\"id\":87700,\"name\":\"The Fallen Star\",\"slug\":\"the-fallen-star\"},{\"id\":72095,\"name\":\"The Legacy of Cain\",\"slug\":\"the-legacy-of-cain\"},{\"id\":72221,\"name\":\"A Shattered Crown\",\"slug\":\"a-shattered-crown\"},{\"id\":72061,\"name\":\"Reign of the Black King\",\"slug\":\"reign-of-the-black-king\"},{\"id\":117779,\"name\":\"Sword of the Stranger\",\"slug\":\"sword-of-the-stranger\"},{\"id\":72738,\"name\":\"The Broken Blade\",\"slug\":\"the-broken-blade\"},{\"id\":73236,\"name\":\"The Doom in Wortham\",\"slug\":\"the-doom-in-wortham\"},{\"id\":72546,\"name\":\"Trailing the Coven\",\"slug\":\"trailing-the-coven\"},{\"id\":72801,\"name\":\"The Imprisoned Angel\",\"slug\":\"the-imprisoned-angel\"},{\"id\":136656,\"name\":\"Return to New Tristram\",\"slug\":\"return-to-new-tristram\"}]},{\"slug\":\"act-ii\",\"number\":2,\"name\":\"Act II\",\"quests\":[{\"id\":80322,\"name\":\"Shadows in the Desert\",\"slug\":\"shadows-in-the-desert\"},{\"id\":93396,\"name\":\"The Road to Alcarnus\",\"slug\":\"the-road-to-alcarnus\"},{\"id\":74128,\"name\":\"City of Blood\",\"slug\":\"city-of-blood\"},{\"id\":57331,\"name\":\"A Royal Audience\",\"slug\":\"a-royal-audience\"},{\"id\":78264,\"name\":\"Unexpected Allies\",\"slug\":\"unexpected-allies\"},{\"id\":78266,\"name\":\"Betrayer of the Horadrim\",\"slug\":\"betrayer-of-the-horadrim\"},{\"id\":57335,\"name\":\"Blood and Sand\",\"slug\":\"blood-and-sand\"},{\"id\":57337,\"name\":\"The Black Soulstone\",\"slug\":\"the-black-soulstone\"},{\"id\":121792,\"name\":\"The Scouring of Caldeum\",\"slug\":\"the-scouring-of-caldeum\"},{\"id\":57339,\"name\":\"Lord of Lies\",\"slug\":\"lord-of-lies\"}]},{\"slug\":\"act-iii\",\"number\":3,\"name\":\"Act III\",\"quests\":[{\"id\":93595,\"name\":\"The Siege of Bastion\'s Keep\",\"slug\":\"the-siege-of-bastion\'s-keep\"},{\"id\":93684,\"name\":\"Turning the Tide\",\"slug\":\"turning-the-tide\"},{\"id\":93697,\"name\":\"The Breached Keep\",\"slug\":\"the-breached-keep\"},{\"id\":203595,\"name\":\"Tremors in the Stone\",\"slug\":\"tremors-in-the-stone\"},{\"id\":101756,\"name\":\"Machines of War\",\"slug\":\"machines-of-war\"},{\"id\":101750,\"name\":\"Siegebreaker\",\"slug\":\"siegebreaker\"},{\"id\":101758,\"name\":\"Heart of Sin\",\"slug\":\"heart-of-sin\"}]},{\"slug\":\"act-iv\",\"number\":4,\"name\":\"Act IV\",\"quests\":[{\"id\":112498,\"name\":\"Fall of the High Heavens\",\"slug\":\"fall-of-the-high-heavens\"},{\"id\":113910,\"name\":\"The Light of Hope\",\"slug\":\"the-light-of-hope\"},{\"id\":114795,\"name\":\"Beneath the Spire\",\"slug\":\"beneath-the-spire\"},{\"id\":114901,\"name\":\"Prime Evil\",\"slug\":\"prime-evil\"}]},{\"slug\":\"act-v\",\"number\":5,\"name\":\"Act V\",\"quests\":[{\"id\":251355,\"name\":\"The Fall of Westmarch\",\"slug\":\"the-fall-of-westmarch\"},{\"id\":284683,\"name\":\"Souls of the Dead\",\"slug\":\"souls-of-the-dead\"},{\"id\":285098,\"name\":\"The Harbinger\",\"slug\":\"the-harbinger\"},{\"id\":257120,\"name\":\"The Witch\",\"slug\":\"the-witch\"},{\"id\":263851,\"name\":\"The Pandemonium Gate\",\"slug\":\"the-pandemonium-gate\"},{\"id\":273790,\"name\":\"The Battlefields of Eternity\",\"slug\":\"the-battlefields-of-eternity\"},{\"id\":269552,\"name\":\"Breaching the Fortress\",\"slug\":\"breaching-the-fortress\"},{\"id\":273408,\"name\":\"Angel of Death\",\"slug\":\"angel-of-death\"}]}]}");

            var actualAct = actualActResult.Data;
            Assert.True(actualActResult.IsValid);
            Assert.Equal(HttpStatusCode.OK, actualActResult.Code);
            Assert.Equal(expectedActs.Acts.Count, actualAct.Acts.Count);

            for (var i = 0; i < expectedActs.Acts.Count; i++)
            {
                Assert.Equal(expectedActs.Acts[i].Slug, actualAct.Acts[i].Slug);
                Assert.Equal(expectedActs.Acts[i].Number, actualAct.Acts[i].Number);
                Assert.Equal(expectedActs.Acts[i].Name, actualAct.Acts[i].Name);

                for (var j = 0; j < expectedActs.Acts[i].Quests.Count; j++)
                {
                    Assert.Equal(expectedActs.Acts[i].Quests[j].Id, actualAct.Acts[i].Quests[j].Id);
                    Assert.Equal(expectedActs.Acts[i].Quests[j].Name, actualAct.Acts[i].Quests[j].Name);
                    Assert.Equal(expectedActs.Acts[i].Quests[j].Slug, actualAct.Acts[i].Quests[j].Slug);
                }
            }
        }
    }
}