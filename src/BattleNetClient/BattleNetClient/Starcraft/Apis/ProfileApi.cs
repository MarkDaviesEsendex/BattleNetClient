using System.Net.Http;
using System.Threading.Tasks;
using BattleNetClient.Starcraft.Response;

namespace BattleNetClient.Starcraft.Apis
{
    public interface IProfileApi
    {
        Task<IStarcraftProfile> GetAsync(int id, int regionId, string characterName);
    }

    internal class ProfileApi : IProfileApi
    {
        private readonly Region _region;
        private const string Url = "https://us.api.battle.net/sc2/profile/4414793/1/XelxRandar/?locale=en_US&apikey=";
        public ProfileApi(Region region)
        {
            _region = region;
        }

        public async Task<IStarcraftProfile> GetAsync(int id, int regionId, string characterName)
        {
            var client = new HttpClient();
            var responseMessage = await client.GetAsync(Url);
            return await responseMessage.Content.ReadAsAsync<StarcraftProfile>();
        }
    }
}