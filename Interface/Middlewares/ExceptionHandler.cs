using Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Interface.Middlewares
{
    public class ExceptionHandler 
    {
        private readonly RequestDelegate _request;

        public ExceptionHandler(RequestDelegate pipeline)
        {
            _request = pipeline;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request.Invoke(context);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
