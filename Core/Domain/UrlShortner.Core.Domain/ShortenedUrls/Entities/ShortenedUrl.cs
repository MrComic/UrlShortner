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
    public class ShortenedUrl : BaseEntity<int> , IAuditable
    {
        #region Fields    
        public ActualUrl ActualUrl { get; protected set; }
        public VisitCount VisitCount { get; protected set; }
        #endregion
        private ShortenedUrl() { }
        public ShortenedUrl(string Url)
        {
            HandleEvent(new UrlCreated() { Url = Url });
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
                VisitCount != null;
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
                        this.VisitCount = new VisitCount(0);
                    }
                    break;
                case UrlVisited e:
                    {
                        this.VisitCount = new VisitCount(this.VisitCount.Value + 1);
                    }
                    break;
                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }
    }
}
