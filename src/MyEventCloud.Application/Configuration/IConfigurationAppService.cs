using System.Threading.Tasks;
using MyEventCloud.Configuration.Dto;

namespace MyEventCloud.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
