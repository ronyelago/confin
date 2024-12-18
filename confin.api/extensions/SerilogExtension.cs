using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace confin.api.extensions;
public static class SerilogExtension
{
    public static void AddSerilogApi(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
    }
}