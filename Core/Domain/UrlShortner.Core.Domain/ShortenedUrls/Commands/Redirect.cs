using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner.Core.Domain.ShortenedUrls.Commands
{
    public class Redirect
    {
        public Redirect(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
