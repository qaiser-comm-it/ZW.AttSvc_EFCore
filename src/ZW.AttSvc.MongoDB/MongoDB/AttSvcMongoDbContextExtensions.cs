using Volo.Abp;
using Volo.Abp.MongoDB;

namespace ZW.AttSvc.MongoDB;

public static class AttSvcMongoDbContextExtensions
{
    public static void ConfigureAttSvc(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
