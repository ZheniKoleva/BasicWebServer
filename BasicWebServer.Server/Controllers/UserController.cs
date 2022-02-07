using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Controllers
{
    public class UserController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";

        private const string Username = "user";

        private const string Password = "user123";


        public UserController(Request request) 
            : base(request)
        {
        }

        public Response Login() => Html(UserController.LoginForm);

        public Response LogInUser()
        {
            Request.Session.Clear();            

            var usernameMatches = Request.Form["Username"] == UserController.Username;
            var passwordMatches = Request.Form["Password"] == UserController.Password;

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
                return Html($"<h3>Currently logged-in user is with username '{UserController.Username}'</h3>");
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
