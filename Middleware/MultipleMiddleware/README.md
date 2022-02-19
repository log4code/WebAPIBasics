# Multiple Middleware 

Example of a multiple [middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0) delegates in the pipeline and runs for all requests to the API regardless of request URL.

## Explaination

In `Startup.cs` we use Minimal APIs to create a new WebApplication Builder. This builder is used to build an application with no additional configured services. 

```
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
```

Next, define a middleware delegate. This middleware prints out when it starts and when it ends. However, in between those two commands it passes the request further down the pipeline to be processed.

```
app.Use(async (context, next) =>
{
    Console.WriteLine("First middleware start.");
    await next.Invoke();
    Console.WriteLine("First middleware end.");
});
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

## Request response

The response from every request will be 
```
Hello world!!
```

## Console logs

The console will have the following output for every request. Note the order of the output to understand how a request flows through middleware.

```
First middleware start.
Terminal (last) middleware
First middleware end.
```

