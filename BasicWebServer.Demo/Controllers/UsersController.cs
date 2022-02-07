using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {  
        private const string Username = "user";

        private const string Password = "user123";


        public UsersController(Request request)
            : base(request)
        {
        }

        public Response Login() => View();

        public Response LogInUser()
        {
            Request.Session.Clear();

            var usernameMatches = Request.Form["Username"] == Username;
            var passwordMatches = Request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                if (!Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, Request.Session.Id);

                    return Html("<h3>Logged successfully!</h3>", cookies);
                }

                return Html("<h3>Logged successfully!</h3>");
            }

            return Redirect("/Login");
        }


        public Response GetUserData()
        {
            if (Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged-in user is with username '{Username}'</h3>");
            }

            return Redirect("/Login");
        }


        public Response Logout()
        {
            Request.Session.Clear();

            return Html("<h3>Loggout successfully!</h3>");
        }
    }
}
