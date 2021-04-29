using System;
using System.Collections.Generic;
using System.Text;
using UrlShortner.Core.Domain.ShortenedUrls.Events;
using UrlShortner.Core.Domain.ShortenedUrls.ValueObjects;
using UrlShortner.Framework.Domain.Entities;
using UrlShortner.Framework.Domain.Events;
using UrlShortner.Framework.Domain.Exceptions;

namespace UrlShortner.Core.Domain.ShortenedUrls.Entities
{
    public class ShortenedUrl : BaseEntity<int>
    {
        #region Fields    
        public ActualUrl ActualUrl { get; protected set; }
        public VisitCount ViewdCount { get; protected set; }
        #endregion

        public ShortenedUrl(string Url)
        {
            HandleEvent(new UrlCreated() { Url = Url, Code = Code });
        }


        public void AddToVisitCount()
        {
            HandleEvent(new UrlVisited());
            ValidateInvariants();
        }

        protected override void ValidateInvariants()
        {
            var isValid =
                ActualUrl != null &&
                ViewdCount != null;
            if (!isValid)
            {
                throw new CustomExceptionsBase("وضعیت آدرس وارد شده ناصحیح میی باشد");
            }
        }

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case UrlCreated e:
                    {
                        this.ActualUrl = new ActualUrl(e.Url);
                    }
                    break;
                case UrlVisited e:
                    {
                        this.ViewdCount = new VisitCount(this.ViewdCount.Value + 1);
                    }
                    break;
                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }
    }
}
