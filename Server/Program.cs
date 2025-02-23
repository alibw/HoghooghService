using Microsoft.AspNetCore.Http.Timeouts;
using Server;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(110);
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(110);
});

var app = builder.Build();

app.UseMiddleware<HubMiddleware>();

app.MapPost("/Calculate", async (HttpContext context, string month, string year, int timeout) =>
{
    try
    {
        await Task.Delay(timeout * 1000);
        return Results.Ok("Request completed successfully");
    }
    catch (OperationCanceledException)
    {
        return Results.StatusCode(408);
    }
});

app.Run();