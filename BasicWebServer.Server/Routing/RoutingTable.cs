using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable() => routes = new()
        {
            [Method.GET] = new(),
            [Method.POST] = new(),
            [Method.PUT] = new(),
            [Method.DELETE] = new()
        };


        public IRoutingTable Map(Method method, 
            string path, 
            Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            routes[method][path] = responseFunction;

            return this;          
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFunction)
            => Map(Method.GET, path, responseFunction);
     

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction)
            => Map(Method.POST, path, responseFunction);

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!routes.ContainsKey(requestMethod)
                || !routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
