using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortner.Core.ApplicationServices.ShortenedUrls.CommandHandlers;
using UrlShortner.Core.Domain.ShortenedUrls.Commands;
using UrlShortner.Endpoints.Api.BaseClasses;
using UrlShortner.Endpoints.Api.Model;
using UrlShortner.Framework.Domain.ApplicationServices;
using UrlShortner.Framework.Domain.Exceptions;

namespace UrlShortner.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : BaseApi
    {
        [HttpPost]
        [Route("create/{Url}")]
        public ApiResponse<string> Post([FromServices] CreateHandler handler, Create request)
        {
               int result =  handler.Handle(request);
                return new ApiResponse<string>()
                {
                    Success = true,
                    Message = "آدرس با موفقیت ایجاد شد"
                    ,
                    Data = string.Concat("/api/url/", result)
                };
        }
    }
}
