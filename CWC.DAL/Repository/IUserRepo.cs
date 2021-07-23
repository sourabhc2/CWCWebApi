using CWC.DAL.Entity;
using CWC.Models.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.DAL.Repository
{
   public interface IUserRepo:IDisposable
    {
        Users ValidateUser(Users entity);
        Users RefreshToken(RefreshTokenReqDTOs item);
        int AddUser(Users item);
        int UpdateUser(Users item);
        int RemoveUser(int Id,int userid);
        Users GetUser(int userid);
        List<Users> GetUsers();

    }
}
