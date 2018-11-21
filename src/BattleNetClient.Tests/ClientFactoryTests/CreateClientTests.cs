using System.Threading.Tasks;
using BattleNetClient.Testing;
using Xunit;

namespace BattleNetClient.Tests.ClientFactoryTests
{
    public class CreateClientTests
    {
        private readonly BattleNetClientFactory _factory;

        public CreateClientTests()
        {
            var server = new BattleNetServerBuilder()
                .CreateClientCredentials("clientId", "clientSecret")
                .Build();

            _factory = new BattleNetClientFactory(Region.UnitedStates, server.GetClient());
        }

        [Fact]
        public async Task WhenClientIsCreatedWithIncorrectCredential_ThenClientIsNonAuthenticated()
        {
            var client = await _factory.CreateClientAsync("", "");
            Assert.False(client.IsClientValid);
        }

        [Fact]
        public async Task WhenClientIsCreated_ThenValidClientIsReturned()
        {
            var battleNetClient = await _factory.CreateClientAsync("clientId", "clientSecret");
            Assert.True(battleNetClient.IsClientValid);
        }
    }
}