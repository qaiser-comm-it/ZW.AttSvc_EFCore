using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ZW.AttSvc;

[DependsOn(
    typeof(AttSvcDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AttSvcApplicationContractsModule : AbpModule
{

}
