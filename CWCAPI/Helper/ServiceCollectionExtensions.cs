using CWC.DAL.Context;
using CWC.DAL.Implementation;
using CWC.DAL.Repository;
using CWCAPI.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWCAPI.Helper
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepo, TokenRepo>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IManageVendors, ManageVendorsService>();
            services.AddSingleton<DapperContext>();
            services.AddScoped<IInventoryRepo, InventoryRepo>();
            services.AddScoped<IPermissionRepo, PermissionRepo>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        }
        }
}
