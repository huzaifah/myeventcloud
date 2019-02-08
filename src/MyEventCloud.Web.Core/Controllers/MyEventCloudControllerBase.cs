using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyEventCloud.Controllers
{
    public abstract class MyEventCloudControllerBase: AbpController
    {
        protected MyEventCloudControllerBase()
        {
            LocalizationSourceName = MyEventCloudConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
