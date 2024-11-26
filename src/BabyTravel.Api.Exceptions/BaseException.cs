using System.Net;

namespace BabyTravel.Api.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message, HttpStatusCode statusCode) : base(message) 
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
