using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType)
            : base(StatusCode.OK)
        {
            Guard.AgainstNull(content);
            Guard.AgainstNull(contentType);

            Headers.Add(Header.ContentType, contentType);
            Body = content;
        }
    }
}
