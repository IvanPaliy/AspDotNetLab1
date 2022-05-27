using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace AspDotNetLab1
{
    public class SecretMiddleware
    {
        private readonly RequestDelegate _next;
        public SecretMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            switch (path)
            {
                case "/secret-1": await context.Response.WriteAsync("secret-1"); break;
                case "/secret-2": await context.Response.WriteAsync("secret-2"); break;
                case "/secret-3": await context.Response.WriteAsync("secret-3"); break;
                default:
                    await _next.Invoke(context);
                    break;
            }
        }
    }
}
