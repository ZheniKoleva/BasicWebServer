namespace BasicWebServer.Server.HTTP
{
    public class Responce
    {
        public Responce(StatusCode statusCode)
        {
            StatusCode = statusCode;

            Headers = new HeaderCollection();
            Headers.Add("Server", "My Web Server");
            Headers.Add("Date", $"{DateTime.UtcNow:R}");
            
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; } 

        public string Body { get; set; }

    }
}
