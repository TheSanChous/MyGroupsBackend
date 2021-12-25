﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using MyGroups.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroups.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var errors = new List<object>();

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    errors.AddRange(validationException.Errors.Select(e => e.ErrorMessage));
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case AuthenticationException authenticationException:
                    code = HttpStatusCode.BadRequest;
                    errors.Add(authenticationException.Message);
                    break;
                case AuthorizationException authorizationException:
                    code = HttpStatusCode.Unauthorized;
                    errors.Add(authorizationException.Message);
                    break;
                default:
                    errors.Add(exception.Message);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var result = JsonSerializer.Serialize(new
            {
                errors = errors
            });

            return context.Response.WriteAsync(result);
        }
    }
}
