using Microsoft.Extensions.DependencyInjection;
using MyGroups.Infrastructure.Abstractions;
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