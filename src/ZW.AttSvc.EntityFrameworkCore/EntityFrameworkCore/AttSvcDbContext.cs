using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ZW.AttSvc.EntityFrameworkCore;

[ConnectionStringName(AttSvcDbProperties.ConnectionStringName)]
public class AttSvcDbContext : AbpDbContext<AttSvcDbContext>, IAttSvcDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DbSet<Test> Test { get; set; }
    public AttSvcDbContext(DbContextOptions<AttSvcDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAttSvc();
    }
}
