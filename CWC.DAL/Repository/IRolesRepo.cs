using CWC.DAL.Entity;
using CWC.Models.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.DAL.Repository
{
    public interface IRolesRepo:IDisposable
    {
        int AddRoles(string role);
        int UpdateRoles(int id, string role);
        int RemoveRoles(int Id);
        List<Roles> GetRoles();

        ///manage Role claims

        int AssignRolesToUser(int userid, List<int> roleid);
        int RemoveUserRoles(int userid, List<int> roleid);
        List<UserRolesResDTOs> GetUserRoles(int userid);
    }
}
