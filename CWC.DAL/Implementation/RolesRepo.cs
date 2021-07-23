using CWC.DAL.Data;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWC.DAL.Implementation
{
   public class RolesRepo: IRolesRepo
    {
        private readonly CWCContext _dbcontext;


        public RolesRepo(CWCContext dbcontext)
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



        public int AddRoles(string role)
        {
            var roles = new Roles
            {
                Role = role,
                Isactive = true
            };
            _dbcontext.Roles.Add(roles);
            _dbcontext.SaveChanges();
            return roles.RoleId;
        }
        public int UpdateRoles(int id, string role)
        {
            var roles = _dbcontext.Roles.Where(r => r.RoleId == id).FirstOrDefault();
            roles.Role = role;
            _dbcontext.Roles.Update(roles);
            _dbcontext.SaveChanges();
            return roles.RoleId;
        }
        public int RemoveRoles(int Id)
        {
            var roles = _dbcontext.Roles.Where(r => r.RoleId == Id).FirstOrDefault();
            roles.Isactive = false;
            _dbcontext.Roles.Update(roles);
            _dbcontext.SaveChanges();
            return roles.RoleId;
        }
        public List<Roles> GetRoles()
        {
            var roles = _dbcontext.Roles.Where(r => r.Isactive == true).ToList();
            return roles;
        }


        //end


        //user roles

        public int AssignRolesToUser(int userid, List<int> roleid)
        {
            var userrole = new UserRoles
            {
                IsActive = true,
                UserId = userid
            };

            foreach (var Id in roleid)
            {
                userrole.RoleId = Id;
                _dbcontext.UserRoles.Add(userrole);
                _dbcontext.SaveChanges();
            }
            return userrole.UserId;
        }
        public int RemoveUserRoles(int userid, List<int> roleid)
        {
            var userroles = _dbcontext.UserRoles.Where(r => r.UserId == userid && r.IsActive == true).ToList();

            foreach (var userrole in userroles)
            {
                foreach (var id in roleid)
                {
                    if (userrole.RoleId == id)
                    {
                        userrole.IsActive = false;
                        _dbcontext.UserRoles.Update(userrole);
                        _dbcontext.SaveChanges();
                    }
                }
            }
            return userroles.FirstOrDefault().RoleId;
        }
        public List<UserRolesResDTOs> GetUserRoles(int userid)
        {
            var userroles = (from r in _dbcontext.UserRoles.Where(r => r.UserId == userid && r.IsActive == true)
                             orderby r.UserRolesId
                             select new UserRolesResDTOs
                             {
                                 RoleId = r.RoleId

                             }).ToList();

            return userroles;


        }

    }
}
