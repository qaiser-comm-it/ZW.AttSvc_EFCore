using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace ZW.AttSvc
{
    public class Test : AggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }
        public virtual string Name { get; set; }
    }
}
