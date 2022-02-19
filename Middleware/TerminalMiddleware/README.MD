# Terminal Middleware 

Example of a [middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0) delegate that is the terminal (last) middleware in the pipeline and runs for all requests to the API regardless of request URL.

## Explaination

In `Startup.cs` we use Minimal APIs to create a new WebApplication Builder. This builder is used to build an application with no additional configured services. 

```
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
```

Then, an anonymous `RequestDelegate` is defined as the terminal (or last) middleware function that will be executed for all incoming requests to the application.

This anonymous function performs 2 tasks.
- It logs out to the console a message indicating it was ran
- It returns 'Hello world!!' as the respone to the Request

```
app.Run(async context =>
{
    Console.WriteLine("Terminal (last) middleware");
    await context.Response.WriteAsync("Hello world!!");
});
```
Lastly, the WebApplication is ran in a blocking fashion (continues to accept requests) until it is shut down.

```
app.Run();
```

## Running the app

From the command line in the application folder:

```
dotnet watch run
```

This command will run the application AND open the default page in a web browser.


