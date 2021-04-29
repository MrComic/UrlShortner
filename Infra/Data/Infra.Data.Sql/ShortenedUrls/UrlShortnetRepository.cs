using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Core.Domain.ShortenedUrls.Data;

namespace UrlShortner.Infra.Data.SqlServer.ShortenedUrls
{
    public class UrlShortnetRepository : IUrlShortnerRepository, IDisposable
    {
        public void Dispose()
        {
            this.applicationDbContext.Dispose();
        }

        private readonly ApplicationDbContext applicationDbContext;

        public UrlShortnetRepository(ApplicationDbContext advertismentDbContext)
        {
            this.applicationDbContext = advertismentDbContext;
        }
    }
}
