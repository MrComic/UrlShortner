using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortner.Core.Domain
{
    public abstract class BaseEntity<Key>
    {
        public Key Id { get; set; }

        protected abstract void ValidateInvariants();
    }
}
