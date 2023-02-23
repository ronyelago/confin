using System.Net;
using Newtonsoft.Json;
using Serilog;

namespace confin.api.middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Log.Error(exception, "Error");

            var code = HttpStatusCode.InternalServerError;
            
            var result = JsonConvert.SerializeObject(new 
            { 
                error = $"{ exception?.Message }; {exception?.InnerException?.Message}"
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}