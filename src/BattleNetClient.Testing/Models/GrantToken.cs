using Newtonsoft.Json;

namespace BattleNetClient.Testing.Models
{
    public class GrantToken
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
    }
}