using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyEventCloud.MultiTenancy.Dto;

namespace MyEventCloud.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

