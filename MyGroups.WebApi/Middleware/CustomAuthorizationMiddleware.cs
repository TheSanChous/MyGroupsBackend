using Microsoft.AspNetCore.Http;
using MyGroups.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Middleware
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate next;

        public CustomAuthorizationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IAuthorizationService authorizationService)
        {
            await authorizationService.AuthorizeAsync(context.User);

            await next?.Invoke(context);
        }
    }
}
