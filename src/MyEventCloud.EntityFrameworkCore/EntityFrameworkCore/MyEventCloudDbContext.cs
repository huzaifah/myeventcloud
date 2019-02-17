using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyEventCloud.Authorization.Roles;
using MyEventCloud.Authorization.Users;
using MyEventCloud.MultiTenancy;
using MyEventCloud.Events;

namespace MyEventCloud.EntityFrameworkCore
{
    public class MyEventCloudDbContext : AbpZeroDbContext<Tenant, Role, User, MyEventCloudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }

        public MyEventCloudDbContext(DbContextOptions<MyEventCloudDbContext> options)
            : base(options)
        {
        }
    }
}
