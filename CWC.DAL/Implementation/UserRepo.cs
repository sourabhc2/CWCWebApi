using CWC.DAL.Data;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CWC.DAL.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly CWCContext _context;
        private readonly ITokenRepo _tokenRepo;
        public UserRepo(CWCContext context, ITokenRepo tokenRepo)
        {
            _context = context;
            _tokenRepo = tokenRepo;
        }
        #region [Disposed]
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
        public int AddUser(Users item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
            return item.UserId;
        }

        public Users GetUser(int userid)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userid);
        }

        public List<Users> GetUsers()
        {
            return _context.Users.Where(u => u.IsDeleted == false).ToList();
        }

        public int RemoveUser(int Id,int userid)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == Id);
            if (user is null) return 0;
            user.IsDeleted = true;
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = userid;
            _context.Users.Update(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public int UpdateUser(Users item)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == item.UserId);
            if (user is null) return 0;
            user.Email = item.Email;
            user.Password = item.Password;
            user.ModifiedDate = item.ModifiedDate;
            user.ModifiedBy = item.ModifiedBy;
            _context.Users.Update(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public Users ValidateUser(Users entity)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == entity.Email && u.Password == entity.Password);
            if (user is null) return null;
            
            var claims = new List<Claim>
            {
            new Claim("name", user.Email),
            new Claim("id", user.UserId.ToString()),
            new Claim("email", user.Email.ToString()),
            new Claim(ClaimTypes.Role, _context.Roles.FirstOrDefault(x=>x.RoleId==user.RoleId).Role)
            };
            var accessToken = _tokenRepo.GenerateAccessToken(claims);
            var refreshToken = _tokenRepo.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            _context.SaveChanges();
            user.Token = accessToken;
            return user;
        }

        public Users RefreshToken(RefreshTokenReqDTOs item)
        {
            string accessToken = item.Token;
            string refreshToken = item.RefreshToken;
            var principal = _tokenRepo.GetPrincipalFromExpiredToken(accessToken);
            var userId = Convert.ToInt32(principal.Claims.FirstOrDefault(x => x.Type == "id").Value);
            var user = _context.Users.SingleOrDefault(u => u.UserId == userId);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;// Invalid client request
            }
            var newAccessToken = _tokenRepo.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenRepo.GenerateRefreshToken();
            user.Token = newAccessToken;
            user.RefreshToken = newRefreshToken;
            _context.SaveChanges();
            return user;
        }
    }
}
