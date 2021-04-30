using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Core.Domain.ShortenedUrls.Data;
using UrlShortner.Core.Domain.ShortenedUrls.Entities;

namespace UrlShortner.Infra.Data.SqlServer.ShortenedUrls
{
    public class UrlShortnetRepository : IUrlShortnerRepository, IDisposable
    {
        public void Dispose()
        {
            this.applicationDbContext.Dispose();
        }

        public void add(ShortenedUrl url)
        {
            applicationDbContext.ShortenedUrls.Add(url);
        }

        public ShortenedUrl Load(int id)
        {
            return applicationDbContext.ShortenedUrls.SingleOrDefault(p=>p.Id==id);
        }

        private readonly ApplicationDbContext applicationDbContext;

        public UrlShortnetRepository(ApplicationDbContext advertismentDbContext)
        {
            this.applicationDbContext = advertismentDbContext;
        }
    }
}
