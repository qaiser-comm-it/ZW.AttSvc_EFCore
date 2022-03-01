using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;
using ZW.AttSvc.EntityFrameworkCore;
using ZW.Shared.Hosting.Microservices.DbMigrations.EfCore;

namespace ZW.AttSvc.DbMigrations
{
    public class AttSvcDatabaseMigrationChecker: PendingEfCoreMigrationsChecker<AttSvcDbContext>
    {
        public AttSvcDatabaseMigrationChecker(
          IUnitOfWorkManager unitOfWorkManager,
          IServiceProvider serviceProvider,
          ICurrentTenant currentTenant,
          IDistributedEventBus distributedEventBus)
          : base(
              unitOfWorkManager,
              serviceProvider,
              currentTenant,
              distributedEventBus,
              AttSvcDbProperties.ConnectionStringName)
        {

        }
    }
}
