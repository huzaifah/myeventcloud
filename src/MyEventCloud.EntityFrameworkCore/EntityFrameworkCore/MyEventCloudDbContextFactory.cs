using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyEventCloud.Configuration;
using MyEventCloud.Web;

namespace MyEventCloud.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyEventCloudDbContextFactory : IDesignTimeDbContextFactory<MyEventCloudDbContext>
    {
        public MyEventCloudDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyEventCloudDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyEventCloudDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyEventCloudConsts.ConnectionStringName));

            return new MyEventCloudDbContext(builder.Options);
        }
    }
}
