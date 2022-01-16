using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    internal class TextResponse : ContentResponse
    {
        public TextResponse(string text) 
            : base(text, ContentType.PlainText)
        {
        }
    }
}
