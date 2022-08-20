using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _request;

        public AuthMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            var userId = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (userId != null)
            {
                context.Items["User"] = userId;
            }

            await _request(context);
        }
    }
}
