namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            headers = new Dictionary<string, Header>();
        }

        public int Count => headers.Count;

        public void Add(string name, string value)
        {
            var header = new Header(name, value);

            headers.Add(name, header);
        }
    }
}
