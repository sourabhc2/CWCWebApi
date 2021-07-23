using CWC.DAL.Entity;
using CWC.Models.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DAL.Repository
{
    public interface IPermissionRepo:IDisposable
    {

       
       Task<List<RoleClaimsResDTOs>> GetRolesClaims(int RolesId);
        int  AddRolesClaims(int RolesId, string roleclaimvalue, string claimtype);
        int RemoveRolesClaims(int RolesId,string roleclaimvalue);
    }
}
