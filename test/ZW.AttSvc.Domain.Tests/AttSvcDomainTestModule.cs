using ZW.AttSvc.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ZW.AttSvc;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(AttSvcEntityFrameworkCoreTestModule)
    )]
public class AttSvcDomainTestModule : AbpModule
{

}
