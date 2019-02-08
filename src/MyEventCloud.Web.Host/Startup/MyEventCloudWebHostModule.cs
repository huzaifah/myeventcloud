using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyEventCloud.Configuration;

namespace MyEventCloud.Web.Host.Startup
{
    [DependsOn(
       typeof(MyEventCloudWebCoreModule))]
    public class MyEventCloudWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyEventCloudWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyEventCloudWebHostModule).GetAssembly());
        }
    }
}
