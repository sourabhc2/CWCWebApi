using CWC.DAL.Data;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DAL.Implementation
{
    public class PermissionRepo : IPermissionRepo
    {

        private readonly CWCContext _dbcontext;


        public PermissionRepo(CWCContext dbcontext)
        {

            _dbcontext = dbcontext;


        }
        #region [Disposed]
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        //// Role Claims
        ///
        ///

        public async Task<List<RoleClaimsResDTOs>> GetRolesClaims(int RolesId)
        {
           
                var roleclaims =await  (from r in _dbcontext.RoleClaims.Where(r => r.IsActive == true && r.RoleId == RolesId)
                                  select new RoleClaimsResDTOs
                                  {
                                      ClaimType = r.ClaimType,
                                      ClaimValue = r.ClaimValue
                                  }).ToListAsync();
            return roleclaims;
        }
        public int AddRolesClaims(int RolesId, string roleclaimvalue,string claimtype)
        {
            var roleclaim = new RoleClaims();
            roleclaim.ClaimValue = roleclaimvalue;
            roleclaim.ClaimType = claimtype;
            roleclaim.RoleId = RolesId;
            roleclaim.IsActive = true;

            _dbcontext.RoleClaims.Add(roleclaim);
            _dbcontext.SaveChanges();
            return roleclaim.Id;
        }
        public int RemoveRolesClaims(int RolesId, string roleclaimvalue)
        {

            var roleclaim = _dbcontext.RoleClaims.Where(r => r.RoleId == RolesId && r.ClaimValue == roleclaimvalue).FirstOrDefault();
            roleclaim.IsActive = false;
            _dbcontext.RoleClaims.Update(roleclaim);
            _dbcontext.SaveChanges();
            return roleclaim.Id;

        }


    }
}
