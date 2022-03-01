using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ZW.AttSvc.MongoDB;

[ConnectionStringName(AttSvcDbProperties.ConnectionStringName)]
public interface IAttSvcMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
