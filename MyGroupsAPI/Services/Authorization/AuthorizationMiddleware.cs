using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Services.Authorization
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAuthorizationService authorizationService)
        {
            authorizationService.CurrentUser = authorizationService.Authorize(httpContext.User);
            await next(httpContext);
        }
    }

    public static class AuthorizationMiddlewareExtension
    {
        public static IApplicationBuilder UseClaimAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
