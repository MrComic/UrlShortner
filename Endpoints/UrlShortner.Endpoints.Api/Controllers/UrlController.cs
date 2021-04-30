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
        /// <summary>
        /// ارسال و ثبت لینک و دریافت کد کوتاه شده
        /// </summary>
        [HttpPost]
        [Route("create")]
        public ApiResponse<string> Post([FromServices] CreateHandler handler, Create request)
        {
               int result =  handler.Handle(request);
                return new ApiResponse<string>()
                {
                    Success = true,
                    Message = "آدرس با موفقیت ایجاد شد"
                    ,
                    Data = string.Concat(this.Request.Scheme,"://", this.Request.Host, "/api/url/", result)
                };
        }

        /// <summary>
        /// دریافت شناسه و هدایت به لینک ثبت شده 
        /// </summary>
        /// <param name="id">شناسه لینک</param>
        /// <returns>Redirect</returns>
        [HttpGet]
        [Route("{id}")]
        public RedirectResult Get([FromServices] RequestToRedirectHandler handler,int id)
        {
            string result = handler.Handle(new Redirect(id));
            return Redirect(result);
        }

    }
}
