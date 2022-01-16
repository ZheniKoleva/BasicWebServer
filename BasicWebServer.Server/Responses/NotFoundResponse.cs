using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse(StatusCode statusCode)
            : base(StatusCode.NotFount)
        {
        }
    }
}
