using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MvcMovie.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext contex)
        {
            try
            {
                await _next(contex);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(e, contex);
            }
        }

        private static Task HandleExceptionAsync(Exception e, HttpContext context)
        {
            var responseBody = JsonConvert.SerializeObject(new {error = e.Message});
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(responseBody);
        }
    }
}