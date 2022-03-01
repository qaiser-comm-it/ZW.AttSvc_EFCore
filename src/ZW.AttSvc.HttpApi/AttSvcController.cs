using ZW.AttSvc.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ZW.AttSvc;

public abstract class AttSvcController : AbpControllerBase
{
    protected AttSvcController()
    {
        LocalizationResource = typeof(AttSvcResource);
    }
}
