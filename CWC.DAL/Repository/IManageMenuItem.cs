using CWC.DAL.Entity;
using CWC.Models.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DAL.Repository
{
    public interface IManageMenuItem:IDisposable
    {
        int Add(Menuitems model, int vendorid);
        int Update(Menuitems model,int vendorid);
        List<Menuitems> Gets(int status);
        Menuitems Get(int id);
        bool Remove(int Id, string name);
        bool Apprv(int id);


    }
}
