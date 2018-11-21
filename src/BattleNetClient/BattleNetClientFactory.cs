using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BattleNetClient.Clients;
using BattleNetClient.Diablo;

namespace BattleNetClient
{
    public class BattleNetClientFactory
    {
        private readonly Region _region;
        private readonly HttpClient _client;

        public BattleNetClientFactory(Region region, HttpClient client = null)
        {
            _region = region;
            _client = client ?? new HttpClient();
        }

        public async Task<IBattleNetClient> CreateClientAsync(string clientId, string clientSecret)
        {
            var response = await MakeAuthenticationRequest(clientId, clientSecret);
            if (!response.IsSuccessStatusCode)
                return new NullClient();

            var tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            return CreateClient();
        }

        private async Task<HttpResponseMessage> MakeAuthenticationRequest(string clientId, string clientSecret)
        {
            var authenticationHeaderValue = CreateAuthenticationHeader(clientId, clientSecret);
            _client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            return await _client.PostAsync("https://us.battle.net/oauth/token", new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                    {new KeyValuePair<string, string>("grant_type", "client_credentials")}));
        }

        private Clients.BattleNetClient CreateClient()
        {
            var clientHelper = new ClientHelper(_client, _region);
            var actClient = new ActClient(clientHelper);
            var diabloClient = new DiabloClient(actClient);
            return new Clients.BattleNetClient(diabloClient);
        }

        private static AuthenticationHeaderValue CreateAuthenticationHeader(string clientId, string clientSecret) => new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));
    }
}