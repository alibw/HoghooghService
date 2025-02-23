using System.Text;

namespace Server;

public class HubMiddleware
{ 
    private readonly RequestDelegate _next;

    public HubMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var queryString = context.Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Black;
        var sb = new StringBuilder();
        foreach (var keyValuePair in queryString)
        {
            sb.Append($"{keyValuePair.Key} : {keyValuePair.Value} | ");
        }
        
        Console.WriteLine(sb.ToString());
        
        var timeOut = context.Request.Query["timeout"];

        int timeout = string.IsNullOrEmpty(timeOut) ? 60 : int.Parse(timeOut);

        context.Items["timeout"] = timeout;

        await _next(context);
    }
}