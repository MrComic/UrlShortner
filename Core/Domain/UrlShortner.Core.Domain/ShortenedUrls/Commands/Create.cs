using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UrlShortner.Framework.Domain.Exceptions;

namespace UrlShortner.Core.Domain.ShortenedUrls.Commands
{
    public class Create
    {
        private string url { get; set; }
        public string Url
        {
            get { return url; }
            set
            {
                if (!Regex.IsMatch(value, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"))
                    throw new CustomExceptionsBase("آدرس ارسالی اشتباه می باشد");
                url = value;
            }
        }
    }
}
