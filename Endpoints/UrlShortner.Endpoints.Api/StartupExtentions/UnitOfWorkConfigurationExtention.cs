using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Framework.Domain.Data;
using UrlShortner.Infra.Data.SqlServer;

namespace UrlShortner.Endpoints.Api.StartupExtentions
{
    public static class UnitOfWorkConfigurationExtention
    {
        public static IServiceCollection ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,ApplicationUnitOfWork>();
            return services;
        }
    }
}
