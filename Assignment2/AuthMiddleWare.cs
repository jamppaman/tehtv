using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Assignment2 {

    public class AuthMiddleWare {
        RequestDelegate _Next;
        IConfiguration _Configuration;

        public AuthMiddleWare (RequestDelegate next, IConfiguration configuration) {
            _Next = next;
            _Configuration = configuration;
        }
        public async Task Invoke (HttpContext context) {
            // Dictionary<string, int> randomDic = new Dictionary<string, int>();
            var apiKeyValue = _Configuration["ApiKey"];
            var userApiKey = context.Request.Headers["x-api-key"];

            if( userApiKey == ""){
                context.Response.StatusCode = 400;
            }
            if (userApiKey == apiKeyValue) {
                await _Next.Invoke (context);
            } else {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync ("Bad Key");
            }
        }
    }
}