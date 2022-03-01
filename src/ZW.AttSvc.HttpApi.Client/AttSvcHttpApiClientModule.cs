using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZW.AttSvc;

[DependsOn(
    typeof(AttSvcApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AttSvcHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AttSvcApplicationContractsModule).Assembly,
            AttSvcRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AttSvcHttpApiClientModule>();
        });

    }
}
