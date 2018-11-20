namespace BattleNetClient.Testing
{
    public class BasicAuthorization
    {
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }

        public static BasicAuthorization Parse(string authentication)
        {
            var base64String = authentication.Split(' ')[1];
            var token = Base64Decode(base64String);
            var clientInfo = token.Split(":");
            return clientInfo.Length != 2
                ? null
                : new BasicAuthorization {ClientId = clientInfo[0], ClientSecret = clientInfo[1]};
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}