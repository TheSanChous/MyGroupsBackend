using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Middleware
{
    public static class CustomMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseCustomAuthorization(this IApplicationBuilder builder, string exceptRoute)
        {
            return builder.UseWhen(context => !context.Request.Path.StartsWithSegments(exceptRoute),
                appBuilder =>
                {
                    appBuilder.UseMiddleware<CustomAuthorizationMiddleware>();
                }
            );
        }
    }
}
