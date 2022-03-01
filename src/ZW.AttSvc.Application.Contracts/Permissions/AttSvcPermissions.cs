using Volo.Abp.Reflection;

namespace ZW.AttSvc.Permissions;

public class AttSvcPermissions
{
    public const string GroupName = "AttSvc";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AttSvcPermissions));
    }
}
