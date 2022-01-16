using BasicWebServer.Server;

//var server = new HttpServer("127.0.0.1", 8080);
var server = new HttpServer(routes => routes
 .MapGet("/", new TextResponse("Hello from the server!"))
 .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
 .MapGet("/Redirect", new RedirectResponse("https://softuni.org")));
server.Start();

//=> new HttpServer(routes => routes
//.MapGet("/", new TextResponse("Hello from the server!"))
//.MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
//.MapGet("/Redirect", new RedirectResponse("https://softuni.org")))
//   .Start();
