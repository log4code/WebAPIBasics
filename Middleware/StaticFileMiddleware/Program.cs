// Minimal API usage to create a WebApplication builder and then build it with no additional configured services.
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// static file middleware first (contents in wwwroot directory)
app.UseStaticFiles();

// Create an anonymous terminal RequestDelegate to handle all requests that are not static files.
app.Run(async context =>
{
    Console.WriteLine("Terminal (last) middleware. Static file NOT served.");
    await context.Response.WriteAsync("Hello world!!");
});

// Run the application and respond to all requests until shutdown
app.Run();