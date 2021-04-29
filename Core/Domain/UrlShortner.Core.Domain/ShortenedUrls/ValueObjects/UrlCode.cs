using System;
using System.Collections.Generic;
using System.Text;
using UrlShortner.Framework.Domain.ValueObject;

namespace UrlShortner.Core.Domain.ShortenedUrls.ValueObjects
{
    public class UrlCode : BaseValueObject<UrlCode>
    {
        public string Value { get; private set; }
        public static UrlCode FromString(string value) => new UrlCode(value);
        private UrlCode()
        {

        }

        public UrlCode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("کد ورودی خالی نمی تواند باشد", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(UrlCode otherObject) => Value == otherObject.Value;
    }
}
