using System;
using System.Collections.Generic;
using System.Text;
using UrlShortner.Core.Domain.ValueObject;

namespace UrlShortner.Core.Domain.ShortenedUrls.ValueObjects
{
    public class VisitCount : BaseValueObject<VisitCount>
    {
        public int Value { get; private set; }
        public static VisitCount FromInt(int value) => new VisitCount(value);
        private VisitCount()
        {
        }

        public VisitCount(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("کد ورودی باید بزرگتر از صفر باشد", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(VisitCount otherObject) => Value == otherObject.Value;
    }
}
