using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Core.Domain.ShortenedUrls.Entities;

namespace UrlShortner.Core.Domain.ShortenedUrls.Data
{
    public interface IUrlShortnerRepository
    {
        void add(ShortenedUrl url);
        ShortenedUrl Load(int id);
    }
}
