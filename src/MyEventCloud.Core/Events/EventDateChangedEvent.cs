using System;
using Abp.Events.Bus.Entities;

namespace MyEventCloud.Events
{
    public class EventDateChangedEvent : EntityEventData<Event>
    {
        public EventDateChangedEvent(Event entity)
            : base(entity)
        {
        }
    }
}
