var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome To MY First ASP.Net Core App !");

app.Run();
