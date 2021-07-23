using CWC.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.DAL.Repository
{
   public interface IInventoryRepo:IDisposable
    {
        int Add(Inventory item);
        int Update(Inventory item);
        Inventory Get(int inventoryId);
        List<Inventory> Gets(int status);
        int Remove(int inventoryId,string userName);
    }
}
