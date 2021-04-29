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
    public class ShortenedUrl : BaseEntity<Guid>
    {
        #region Fields    
        public ActualUrl ActualUrl { get; protected set; }
        public UrlCode Code { get; protected set; }
        public VisitCount ViewdCount { get; protected set; }
        #endregion

        public ShortenedUrl(string Url, string Code)
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
                Id != null &&
                Code != null &&
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
                        this.Code = new UrlCode(e.Code);
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
