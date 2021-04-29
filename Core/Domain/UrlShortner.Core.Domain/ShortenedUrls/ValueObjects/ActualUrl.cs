using System;
using System.Collections.Generic;
using System.Text;
using UrlShortner.Core.Domain.ValueObject;

namespace UrlShortner.Core.Domain.ShortenedUrls.ValueObjects
{
    public class ActualUrl : BaseValueObject<ActualUrl>
    {
        public string Value { get; private set; }
        public static ActualUrl FromString(string value) => new ActualUrl(value);
        private ActualUrl()
        {

        }
        public ActualUrl(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("مقدار آدرس نمی تواند خالی باشد", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(ActualUrl otherObject) => Value == otherObject.Value;

        public static implicit operator string(ActualUrl actualUrl) => actualUrl.Value;
    }
}
