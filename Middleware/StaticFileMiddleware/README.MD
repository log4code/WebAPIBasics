# Terminal Middleware 

Example of enabling [static file middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-6.0). Enabling this servers static files from the web root of the project directory

## Explaination

In `Startup.cs` we use Minimal APIs to create a new WebApplication Builder. This builder is used to build an application with no additional configured services. 

```
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
```

Next, the `UseStaticFiles` middleware is enabled. This allows the appliction to server static files from the web root directory. 

```
app.UseStaticFiles();
```

The default web root directory is named `wwwroot`. Create a top level directory in the project called `wwwroot` and place any files you would like to host there.

![image](https://user-images.githubusercontent.com/48453433/154818083-355c7951-0f1e-4860-a923-6b1a7c7ba797.png)


Then, an anonymous `RequestDelegate` is defined as the terminal (or last) middleware function that will be executed fof all requests NOT servering static files.

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

The console will have the following output for every request where there is not a matching file in wwwroot. If a file is found, this terminal delegate will not be ran.

```
Terminal (last) middleware
```
