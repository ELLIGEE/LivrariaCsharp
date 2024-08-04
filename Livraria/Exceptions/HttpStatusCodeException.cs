using System.Net;

namespace Livraria.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public HttpStatusCodeException() { }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCodeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
