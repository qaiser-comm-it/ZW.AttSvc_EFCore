using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ZW.AttSvc;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AttSvcDomainSharedModule)
)]
public class AttSvcDomainModule : AbpModule
{

}
