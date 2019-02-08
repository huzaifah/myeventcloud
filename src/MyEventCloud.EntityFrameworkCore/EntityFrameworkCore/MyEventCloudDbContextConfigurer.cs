using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyEventCloud.EntityFrameworkCore
{
    public static class MyEventCloudDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyEventCloudDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyEventCloudDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
