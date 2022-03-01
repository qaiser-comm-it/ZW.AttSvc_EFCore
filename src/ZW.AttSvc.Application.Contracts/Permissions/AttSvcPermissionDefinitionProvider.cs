using ZW.AttSvc.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ZW.AttSvc.Permissions;

public class AttSvcPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AttSvcPermissions.GroupName, L("Permission:AttSvc"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AttSvcResource>(name);
    }
}
