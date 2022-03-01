using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ZW.AttSvc.EntityFrameworkCore;

[DependsOn(
    typeof(AttSvcDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class AttSvcEntityFrameworkCoreModule : AbpModule
{
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql();
        });

        context.Services.AddAbpDbContext<AttSvcDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}
