using Newtonsoft.Json;

namespace BattleNetClient
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}