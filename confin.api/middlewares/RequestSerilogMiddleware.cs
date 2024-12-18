using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Threading.Tasks;

namespace confin.api.middlewares;
public class RequestSerilogMiddleware
{
    private readonly RequestDelegate _next;

    public RequestSerilogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context)
    {
        using (LogContext.PushProperty("UserName", context?.User?.Identity?.Name ?? "anonimous"))
        {
            return _next.Invoke(context);
        }
    }
}