using CWC.DAL.Implementation;
using CWC.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWCAPI.Permission
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IUserRepo _userManager;
        IRolesRepo _roleManager;
        IPermissionRepo _permissionRepo;

        public PermissionAuthorizationHandler(IUserRepo userManager, IRolesRepo roleManager,IPermissionRepo permissionRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _permissionRepo = permissionRepo;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                return;
            }

            // Get all the roles the user belongs to and check if any of the roles has the permission required
            // for the authorization to succeed.
            var user =  _userManager.GetUser(Convert.ToInt32( context.User.FindFirst("id").Value));
            var userRoles =  _roleManager.GetUserRoles(user.UserId);

            foreach (var role in userRoles)
            {
                var roleClaims = await _permissionRepo.GetRolesClaims(role.RoleId);
                var permissions = roleClaims.Where(x => x.ClaimType == CustomClaimTypes.Permission &&
                                                        x.ClaimValue == requirement.Permission )
                                        .Select(x => x.ClaimValue);

                if (permissions.Any())
                {
                    context.Succeed(requirement);
                    return;
                }
            }
        }
    }
}
