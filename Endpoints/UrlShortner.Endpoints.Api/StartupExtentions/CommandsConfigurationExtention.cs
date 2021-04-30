using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Core.ApplicationServices.ShortenedUrls.CommandHandlers;
using UrlShortner.Core.Domain.ShortenedUrls.Commands;
using UrlShortner.Framework.Domain.ApplicationServices;

namespace UrlShortner.Endpoints.Api.StartupExtentions
{
    public static class CommandsConfigurationExtention
    {
        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<CreateHandler>();
            services.AddScoped<RequestToRedirectHandler>();
        }
    }
}
