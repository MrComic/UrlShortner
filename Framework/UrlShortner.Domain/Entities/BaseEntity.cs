using System;
using System.Collections.Generic;
using System.Linq;
using UrlShortner.Framework.Domain.Events;

namespace UrlShortner.Framework.Domain.Entities
{
    public abstract class BaseEntity<Key> where Key : IEquatable<Key>
    {
        public Key Id { get; set; }

        protected abstract void ValidateInvariants();


        private readonly List<IEvent> _events;
        protected BaseEntity() => _events = new List<IEvent>();
        protected abstract void SetStateByEvent(IEvent @event);
        public IEnumerable<IEvent> GetEvents() => _events.AsEnumerable();
        public void ClearEvents() => _events.Clear();
        protected void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            ValidateInvariants();
            _events.Add(@event);
        }


        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<Key>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            //if (Key == default || other.Id == default)
            //    return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<Key> a, BaseEntity<Key> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<Key> a, BaseEntity<Key> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
