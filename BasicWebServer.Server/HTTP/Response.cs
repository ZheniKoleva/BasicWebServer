using System.Text;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
           
            Headers.Add(Header.Server, "My Web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:R}");       
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public CookieCollection Cookies { get; } = new CookieCollection();

        public string Body { get; set; }       

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)StatusCode} {StatusCode}");

            foreach (var header in Headers)
            {
                result.AppendLine(header.ToString());
            }

            foreach (var cookie in Cookies) 
            { 
                result.AppendLine($"{Header.SetCookie}: {cookie}");
            }

            result.AppendLine();

            if (!string.IsNullOrEmpty(Body))
            {
                result.Append(Body);
            }

            return result.ToString();
        }

    }
}
