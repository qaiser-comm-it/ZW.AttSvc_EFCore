using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ZW.AttSvc;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AttSvcHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AttSvcConsoleApiClientModule : AbpModule
{

}
