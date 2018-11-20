using Newtonsoft.Json;

namespace BattleNetClient.Testing.Models
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}