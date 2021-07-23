using CWC.DAL.Data;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.DAL.Implementation
{
   public class ManageMenuItemService : IManageMenuItem
    {
        private readonly CWCContext _dbcontext;
       

        public ManageMenuItemService(CWCContext dbcontext)
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

        public int Add(Menuitems model,int vendorid)
        {
            if (model.ItemApprvFrmSuperAdm != true)
            model.ItemApprvFrmSuperAdm = false;
            model.ItemDelFromSuperAdm = false;

            var inventory = new Inventory();
            inventory.ItemName = model.Food_Item_Name;
            inventory.Price = (int)model.Price;
            inventory.VendorID = vendorid;
            _dbcontext.Inventory.Add(inventory);
            _dbcontext.SaveChanges();

            model.InventoryID = inventory.InventoryId;
            _dbcontext.Menuitems.Add(model);
            _dbcontext.SaveChanges();

            return model.ID;



        }
        public int Update(Menuitems model,int vendorid)
        {
            var menutitem = _dbcontext.Menuitems.Find(model.ID);
            menutitem.Food_Item_Name = model.Food_Item_Name;
            menutitem.Price = model.Price;
            menutitem.Details = model.Details;
            var inventory = _dbcontext.Inventory.Find(menutitem.InventoryID);
            inventory.ItemName = model.Food_Item_Name;
            inventory.Price = (int)model.Price;
            inventory.VendorID = vendorid;

            _dbcontext.Inventory.Update(inventory);
            _dbcontext.SaveChanges();

            _dbcontext.Menuitems.Update(menutitem);
            _dbcontext.SaveChanges();

            return menutitem.ID;
        }

        public List<Menuitems> Gets(int status)
        {
            var isDeleted = status > 0 ? true : false;
            var menuitems = _dbcontext.Menuitems.Where(m => m.ItemDelFromSuperAdm == isDeleted).ToList();
            return menuitems;
        }
      public  Menuitems Get(int id)
        {
            var menuitem = _dbcontext.Menuitems.Find(id);
            return menuitem;
            }
        public bool Remove(int id,string name)
        {
            var menutitem = _dbcontext.Menuitems.Find(id);
            menutitem.ItemDelFromSuperAdm = true;
            menutitem.DeletedBy = name;
            _dbcontext.Menuitems.Update(menutitem);
            _dbcontext.SaveChanges();
            return true;
        }
        public bool Apprv(int id)
        {
            var menutitem = _dbcontext.Menuitems.Find(id);
            menutitem.ItemApprvFrmSuperAdm = true;
            _dbcontext.Menuitems.Update(menutitem);
            _dbcontext.SaveChanges();

            return true;
        }


    }
}
