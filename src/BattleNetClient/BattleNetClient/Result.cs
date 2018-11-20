using System.Net;
using BattleNetClient.Diablo.Models;

namespace BattleNetClient
{
    public interface IResult<out T>
    {
        bool IsValid { get; }
        T Data { get; }
        HttpStatusCode Code { get; }
    }

    public class Result<T> : IResult<T>
    {
        private Result(bool isValid, T data, HttpStatusCode code)
        {
            IsValid = isValid;
            Data = data;
            Code = code;
        }
        
        public bool IsValid { get; }
        public T Data { get; }
        public HttpStatusCode Code { get; }
        
        public static IResult<T> Success(T data) 
            => new Result<T>(true, data, HttpStatusCode.OK);

        public static IResult<T> Failure(T data, HttpStatusCode statusCode) 
            => new Result<T>(false, data, statusCode);
    }
}