using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWCAPI.Permission
{
    public static class Permissions
    {
        public static class Inventory
        {
            public const string View = "Permissions.Inventory.View";
            public const string Create = "Permissions.Inventory.Create";
            public const string Edit = "Permissions.Inventory.Edit";
            public const string Delete = "Permissions.Inventorys.Delete";
            public const string Update = "Permissions.Inventorys.Update";
        }

        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
        }
    }
}
