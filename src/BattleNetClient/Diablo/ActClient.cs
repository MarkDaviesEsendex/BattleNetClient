using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BattleNetClient.Clients;
using BattleNetClient.Diablo.Models;

namespace BattleNetClient.Diablo
{
    public interface IActClient
    {
        Task<IResult<Act>> GetByIdAsync(int actId);
        Task<IResult<ActCollection>> GetAllAsync();
    }
    
    public class ActClient : IActClient
    {
        private readonly ClientHelper _clientHelper;

        public ActClient(ClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
        }

        public async Task<IResult<Act>> GetByIdAsync(int actId)
        {
            var responseMessage =
                await _clientHelper.Client.GetAsync($"https://us.api.blizzard.com/d3/data/act/{actId}");
            return !responseMessage.IsSuccessStatusCode
                ? Result<Act>.Failure(Act.Empty, responseMessage.StatusCode)
                : Result<Act>.Success(await responseMessage.Content.ReadAsAsync<Act>());
        }

        public async Task<IResult<ActCollection>> GetAllAsync()
        {
            var responseMessage =
                await _clientHelper.Client.GetAsync($"https://us.api.blizzard.com/d3/data/act/");
            return !responseMessage.IsSuccessStatusCode
                ? Result<ActCollection>.Failure(ActCollection.Empty, responseMessage.StatusCode)
                : Result<ActCollection>.Success(await responseMessage.Content.ReadAsAsync<ActCollection>());
        }
    }
}