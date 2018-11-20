using System.Net;
using System.Threading.Tasks;
using BattleNetClient.Diablo.Models;

namespace BattleNetClient.Diablo
{
    public class NullActClient : IActClient
    {
        public Task<IResult<Act>> GetByIdAsync(int actId) 
            => Task.FromResult(Result<Act>.Failure(Act.Empty, HttpStatusCode.NotFound));

        public Task<IResult<ActCollection>> GetAllAsync()
            => Task.FromResult(Result<ActCollection>.Failure(ActCollection.Empty, HttpStatusCode.NotFound));
    }
}