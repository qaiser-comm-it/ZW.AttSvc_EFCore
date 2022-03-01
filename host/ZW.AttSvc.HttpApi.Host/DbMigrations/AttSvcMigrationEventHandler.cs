using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;
using ZW.AttSvc.EntityFrameworkCore;
using ZW.Shared.Hosting.Microservices.DbMigrations.EfCore;

namespace ZW.AttSvc.DbMigrations
{
    public class AttSvcMigrationEventHandler : DatabaseEfCoreMigrationEventHandler<AttSvcDbContext>,
                                    IDistributedEventHandler<TenantCreatedEto>,
                                    IDistributedEventHandler<TenantConnectionStringUpdatedEto>,
                                    IDistributedEventHandler<ApplyDatabaseMigrationsEto>
    {
        public AttSvcMigrationEventHandler(
                 ICurrentTenant currentTenant,
            IUnitOfWorkManager unitOfWorkManager,
            ITenantStore tenantStore,
            ITenantRepository tenantRepository,
            IDistributedEventBus distributedEventBus
            ) : base(
                currentTenant,
                unitOfWorkManager,
                tenantStore,
                tenantRepository,
                distributedEventBus,
                AttSvcDbProperties.ConnectionStringName)
        {
        }

        public async Task HandleEventAsync(ApplyDatabaseMigrationsEto eventData)
        {
            if (eventData.DatabaseName != DatabaseName)
            {
                return;
            }

            try
            {
                var schemaMigrated = await MigrateDatabaseSchemaAsync(eventData.TenantId);

                if (eventData.TenantId == null && schemaMigrated)
                {
                    /* Migrate tenant databases after host migration */
                    await QueueTenantMigrationsAsync();
                }
            }
            catch (Exception ex)
            {
                await HandleErrorOnApplyDatabaseMigrationAsync(eventData, ex);
            }
        }

        public async Task HandleEventAsync(TenantCreatedEto eventData)
        {
            try
            {
                await MigrateDatabaseSchemaAsync(eventData.Id);
            }
            catch (Exception ex)
            {
                await HandleErrorTenantCreatedAsync(eventData, ex);
            }
        }

        public async Task HandleEventAsync(TenantConnectionStringUpdatedEto eventData)
        {
            if (eventData.ConnectionStringName != DatabaseName && eventData.ConnectionStringName != ConnectionStrings.DefaultConnectionStringName ||
                eventData.NewValue.IsNullOrWhiteSpace())
            {
                return;
            }

            try
            {
                await MigrateDatabaseSchemaAsync(eventData.Id);

                /* You may want to move your data from the old database to the new database!
                 * It is up to you. If you don't make it, new database will be empty. */
            }
            catch (Exception ex)
            {
                await HandleErrorTenantConnectionStringUpdatedAsync(eventData, ex);
            }
        }
    }
}
