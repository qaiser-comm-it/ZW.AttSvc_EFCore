using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ZW.AttSvc.MongoDB;

[ConnectionStringName(AttSvcDbProperties.ConnectionStringName)]
public class AttSvcMongoDbContext : AbpMongoDbContext, IAttSvcMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureAttSvc();
    }
}
