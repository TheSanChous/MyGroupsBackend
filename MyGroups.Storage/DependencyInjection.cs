using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGroups.Application.Interfaces;
using MyGroups.Storage.Services;

namespace MyGroups.Storage
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<IStorageService, StorageService>();

            return services;
        }
    }
}