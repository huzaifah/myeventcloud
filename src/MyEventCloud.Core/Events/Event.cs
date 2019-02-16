﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;
using MyEventCloud.Domain.Events;

namespace MyEventCloud.Events
{
    [Table("AppEvents")]
    public class Event : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description { get; set; }

        public virtual DateTime Date { get; protected set; }

        public virtual bool IsCancelled { get; protected set; }

        [Range(0, int.MaxValue)]
        public virtual int MaxRegistrationCount { get; protected set; }

        public virtual ICollection<EventRegistration> Registrations { get; protected set; }

        protected Event() { }

        public static Event Create(int tenantId, string title, DateTime date, string description = null, int maxRegistrationCount = 0)
        {
            var @event = new Event
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Title = title,
                Description = description,
                MaxRegistrationCount = maxRegistrationCount
            };

            @event.SetDate(date);

            @event.Registrations = new Collection<EventRegistration>();

            return @event;
        }

        public bool IsInPast()
        {
            return Date < Clock.Now;
        }

        public bool IsAllowedCancellationTimeEnded()
        {
            return Date.Subtract(Clock.Now).TotalHours <= 2.0; // 2 hours can be defined as Event property and predetermined per event
        }

        public void ChangeDate(DateTime date)
        {
            if (date == Date)
            {
                return;
            }

            SetDate(date);
            DomainEvents.EventBus.Trigger(new EventDateChangedEvent(this));
        }

        private void SetDate(DateTime date)
        {
            AssertNotCancelled();

            if (date < Clock.Now)
            {
                throw new UserFriendlyException("Cannot set an event's date in the past");
            }

            if (date <= Clock.Now.AddHours(3))
            {
                throw new UserFriendlyException("Should set an event's date 3 hours before at least");
            }

            Date = date;

            DomainEvents.EventBus.Trigger(new EventDateChangedEvent(this));
        }

        internal void Cancel()
        {
            AssertNotInPast();
        }

        private void AssertNotInPast()
        {
            if (IsInPast())
            {
                throw new UserFriendlyException("This event was in the past");
            }
        }

        private void AssertNotCancelled()
        {
            if (IsCancelled)
            {
                throw new UserFriendlyException("This event is cancelled!");
            }
        }
    }
}
