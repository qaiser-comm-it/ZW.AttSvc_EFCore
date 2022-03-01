using Localization.Resources.AbpUi;
using ZW.AttSvc.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ZW.AttSvc;

[DependsOn(
    typeof(AttSvcApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AttSvcHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AttSvcHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AttSvcResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
