using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyEventCloud.Authorization;

namespace MyEventCloud
{
    [DependsOn(
        typeof(MyEventCloudCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyEventCloudApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyEventCloudAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyEventCloudApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
