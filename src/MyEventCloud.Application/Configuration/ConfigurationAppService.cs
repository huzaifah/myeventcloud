using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyEventCloud.Configuration.Dto;

namespace MyEventCloud.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyEventCloudAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
