using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Framework.Domain.Events;

namespace UrlShortner.Core.Domain.ShortenedUrls.Events
{
    public class UrlCreated:IEvent
    {
        public string Url { get; set; }

        public string Code { get; set; }
    }
}
