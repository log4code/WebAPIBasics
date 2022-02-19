var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async context =>
{
    Console.WriteLine("Terminal (last) middleware");
    await context.Response.WriteAsync("Hello world!!");
});

app.Run();