using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Core.Domain.ShortenedUrls.Data;
using UrlShortner.Infra.Data.SqlServer.ShortenedUrls;

namespace UrlShortner.Endpoints.Api.StartupExtentions
{
    public static class RepositoriesConfigurationExtention
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUrlShortnerRepository, UrlShortnetRepository>();
            return services;
        }
    }
}
