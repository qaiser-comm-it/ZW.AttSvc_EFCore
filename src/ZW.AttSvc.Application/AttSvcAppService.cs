using ZW.AttSvc.Localization;
using Volo.Abp.Application.Services;

namespace ZW.AttSvc;

public abstract class AttSvcAppService : ApplicationService
{
    protected AttSvcAppService()
    {
        LocalizationResource = typeof(AttSvcResource);
        ObjectMapperContext = typeof(AttSvcApplicationModule);
    }
}
