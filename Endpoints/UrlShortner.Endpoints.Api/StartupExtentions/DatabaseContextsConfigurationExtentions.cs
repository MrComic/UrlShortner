using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Infra.Data.SqlServer;

namespace UrlShortner.Endpoints.Api.StartupExtentions
{
    public static class DatabaseContextsConfigurationExtentions
    {
        public static IServiceCollection ConfigureDatabases(this IServiceCollection services,
           IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("dbcontextcnn")));
            return services;
        }
    }
}
