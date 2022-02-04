using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGroups.Application.Common.Authorization;
using MyGroups.Application.Interfaces;
using MyGroups.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IDatabaseContext, DatabaseContext>();

            return services;
        }
    }
}
