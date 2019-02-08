using Abp.Authorization;
using MyEventCloud.Authorization.Roles;
using MyEventCloud.Authorization.Users;

namespace MyEventCloud.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
