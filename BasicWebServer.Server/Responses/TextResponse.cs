using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text,
            Action<Request, Response> preRebderAction = null) 
            : base(text, ContentType.PlainText, preRebderAction)
        {
        }
    }
}
