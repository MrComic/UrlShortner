using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace UrlShortner.Endpoints.Api.StartupExtentions
{

    public class ApiExceptionOptions
    {
        public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }
        public Func<Exception, LogLevel> DetermineLogLevel { get; set; }
    }
}