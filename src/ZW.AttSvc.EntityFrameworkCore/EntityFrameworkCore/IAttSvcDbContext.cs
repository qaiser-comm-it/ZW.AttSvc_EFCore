using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ZW.AttSvc.EntityFrameworkCore;

[ConnectionStringName(AttSvcDbProperties.ConnectionStringName)]
public interface IAttSvcDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
