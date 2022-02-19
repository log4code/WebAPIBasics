
// Minimal API usage to create a WebApplication builder and then build it with no additional configured services.
var builder = WebApplication.CreateBuilder();
var app = builder.Build();

// Create an anonymous terminal RequestDelegate to handle all requests
app.Run(async context =>
{
    Console.WriteLine("Terminal (last) middleware");
    await context.Response.WriteAsync("Hello world!!");
});

// Run the application and respond to all requests until shutdown
app.Run();