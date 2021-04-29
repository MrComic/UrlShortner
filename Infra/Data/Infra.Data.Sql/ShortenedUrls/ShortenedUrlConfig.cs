using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortner.Core.Domain.ShortenedUrls.Entities;
using UrlShortner.Core.Domain.ShortenedUrls.ValueObjects;

namespace UrlShortner.Infra.Data.SqlServer.ShortenedUrls
{
    public class ShortenedUrlConfig : IEntityTypeConfiguration<ShortenedUrl>
    {
        public void Configure(EntityTypeBuilder<ShortenedUrl> builder)
        {
            builder.Property(c => c.ActualUrl).HasConversion(c => c.Value, d => ActualUrl.FromString(d));
            builder.Property(c => c.VisitCount).HasConversion(c => c.Value, d => VisitCount.FromInt(d));
        }
    }
}
