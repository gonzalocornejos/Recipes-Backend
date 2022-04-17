namespace recipes_backend.Exceptions
{
    using System.Net;
    public class AppException : Exception
    {
        public Guid GUID { get; }
        public HttpStatusCode StatusCode { get; }

        public AppException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            GUID = Guid.NewGuid();
            StatusCode = statusCode;
        }
    }
}
