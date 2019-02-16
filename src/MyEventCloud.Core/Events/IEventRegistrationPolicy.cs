using System;
using System.Threading.Tasks;
using Abp.Domain.Services;
using MyEventCloud.Authorization.Users;

namespace MyEventCloud.Events
{
    public interface IEventRegistrationPolicy : IDomainService
    {
        /// <summary>
        /// Checks if given user can register to <see cref="@event"/> and throws exception if can not.
        /// </summary>
        Task CheckRegistrationAttemptAsync(Event @event, User user);
    }
}
