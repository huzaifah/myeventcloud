using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyEventCloud.Authorization.Roles;
using MyEventCloud.Authorization.Users;
using MyEventCloud.MultiTenancy;

namespace MyEventCloud.EntityFrameworkCore
{
    public class MyEventCloudDbContext : AbpZeroDbContext<Tenant, Role, User, MyEventCloudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyEventCloudDbContext(DbContextOptions<MyEventCloudDbContext> options)
            : base(options)
        {
        }
    }
}
