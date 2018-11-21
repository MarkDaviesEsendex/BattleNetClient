using System;
using System.Collections.Generic;
using BattleNetClient.Testing.Data;
using BattleNetClient.Testing.Data.Models;
using BattleNetClient.Testing.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleNetClient.Testing.Controllers
{
    [Route("oauth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<ClientInfo> _clientInfoRepository;
        private readonly IRepository<Token> _tokenRepository;

        public AuthenticationController(IRepository<ClientInfo> clientInfoRepository, IRepository<Token> tokenRepository)
        {
            _clientInfoRepository = clientInfoRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("token")]
        public ActionResult<TokenResponse> GenerateToken([FromHeader(Name = "Authorization")]string authentication, [FromForm]List<KeyValuePair<string, string>> content)
        {
            if (!authentication.StartsWith("Basic "))
                return NotFound();

            var authorization = BasicAuthorization.Parse(authentication);
            if (authorization == null)
                return NotFound();

            var clientInfoFromDb = _clientInfoRepository.GetRecord(info =>
                info.ClientId == authorization.ClientId && info.ClientSecret == authorization.ClientSecret);

            if (clientInfoFromDb == null)
                return NotFound();

            var token = _tokenRepository.InsertRecord(new Token { AccessToken = Guid.NewGuid().ToString()});
            return Ok(new TokenResponse { AccessToken = token.AccessToken});
        }

        [HttpPost("clientInfo")]
        public void CreateClientInformation([FromBody]ClientInfoRequest infoRequest)
            => _clientInfoRepository.InsertRecord(new ClientInfo {ClientId = infoRequest.ClientId, ClientSecret = infoRequest.ClientSecret});
    }
}