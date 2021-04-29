using System;
using System.Collections.Generic;
using System.Text;
using UrlShortner.Core.Domain.Exceptions;
using UrlShortner.Core.Domain.ShortenedUrl.ValueObjects;

namespace UrlShortner.Core.Domain.ShortenedUrl.Entities
{
    public class ShortenedUrl: BaseEntity<Guid>
    {
        #region Fields    
        public ActualUrl ActualUrl { get; protected set; }
        public UrlCode Code { get; protected  set; }
        public VisitCount ViewdCount { get; protected set; }
        #endregion

        public ShortenedUrl(string Url)
        {
            this.ActualUrl = new ActualUrl(Url);
            this.Code = GenerateCode(Url);
            this.ViewdCount = new VisitCount(0);
        }

        private UrlCode GenerateCode(string url) {
            return new UrlCode("");
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



    }
}
