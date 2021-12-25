using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyGroups.Application.Common.Authorization;
using MyGroups.Application.Common.Behaviors;
using MyGroups.Application.Interfaces;
using System.Reflection;

namespace MyGroups.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            return services;
        } 
    }
}
