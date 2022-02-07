using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

public class StartUp
{
    private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";

    private const string Username = "user";

    private const string Password = "user123";  


    public static async Task Main()
    {
        var server = new HttpServer(routes => routes
        .MapGet<HomeController>("/", c => c.Index())
        .MapGet<HomeController>("/Redirect", c => c.Redirect())
        .MapGet<HomeController>("/HTML", c => c.Html())
        .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
        .MapGet<HomeController>("/Content", c => c.Content())
        .MapPost<HomeController>("/Content", c => c.DownloadContent())
        .MapGet<HomeController>("/Cookies", c => c.Cookies())
        .MapGet<HomeController>("/Session", c => c.Session()));

        await server.Start();
        //.MapGet("/Login", new HtmlResponse(StartUp.LoginForm))
        //.MapPost("/Login", new HtmlResponse("", StartUp.LoginAction))
        //.MapGet("/Logout", new HtmlResponse("", StartUp.LogoutAction))
        //.MapGet("/UserProfile", new HtmlResponse("", StartUp.GetUserDataAction)))


    }

    private static void GetUserDataAction(Request request, Response response)
    {
        if (request.Session.ContainsKey(Session.SessionUserKey))
        {
            response.Body = string.Empty;
            response.Body += $"<h3>Currently logged-in user is with username '{Username}'</h3>";
        }
        else
        {
            response.Body = string.Empty;
            response.Body += $"<h3>You should first log in - <a href='/Login'>Login</a></h3>";
        }
    }

    private static void LogoutAction(Request request, Response response)
    {
        request.Session.Clear();

        response.Body = string.Empty;
        response.Body += "<h3>Loggout successfully!</h3>";
    }

    private static void LoginAction(Request request, Response response)
    {
        request.Session.Clear();

        var bodyText = string.Empty;

        var usernameMatches = request.Form["Username"] == StartUp.Username;
        var passwordMatches = request.Form["Password"] == StartUp.Password;

        if (usernameMatches && passwordMatches)
        {
            request.Session[Session.SessionUserKey] = "MyUserId";
            response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

            bodyText = "<h3>Logged successfully!</h3>";
        }
        else
        {
            bodyText = StartUp.LoginForm;
        }

        response.Body = string.Empty;
        response.Body += bodyText;
    }   
   
}




