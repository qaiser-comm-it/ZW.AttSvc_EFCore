using Volo.Abp.Modularity;

namespace ZW.AttSvc;

[DependsOn(
    typeof(AttSvcApplicationModule),
    typeof(AttSvcDomainTestModule)
    )]
public class AttSvcApplicationTestModule : AbpModule
{

}
