using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Request request) 
            : base(request)
        {
        }

        public Response Index() => Text("Hello from the server!");
    }
}
