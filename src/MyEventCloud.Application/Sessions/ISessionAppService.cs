using System.Threading.Tasks;
using Abp.Application.Services;
using MyEventCloud.Sessions.Dto;

namespace MyEventCloud.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
