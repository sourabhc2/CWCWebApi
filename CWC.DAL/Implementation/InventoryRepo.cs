using CWC.DAL.Data;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWC.DAL.Implementation
{
    public class InventoryRepo : IInventoryRepo
    {
        private readonly CWCContext _context;
        public InventoryRepo(CWCContext context)
        {
            _context = context;
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
        public int Add(Inventory item)
        {
            _context.Inventory.Add(item);
            _context.SaveChanges();
            return item.InventoryId;
        }

      

        public Inventory Get(int inventoryId)
        {
            var inventory = _context.Inventory.Find(inventoryId);
            return inventory;
        }

        public List<Inventory> Gets(int status)
        {
            var isDeleted = status > 0 ? true : false;
            var inventory = _context.Inventory.Include(x => x.Vendors).Where(x => x.IsDeleted == isDeleted).ToList();
            return inventory;
        }

        public int Remove(int inventoryId, string userName)
        {
            var inventory = _context.Inventory.Find(inventoryId);
            if (inventory is null)
                return 0;
            inventory.IsDeleted = true;
            inventory.ModifiedBy = userName;
            inventory.ModifiedDate = DateTime.Now;
            _context.Update(inventory);
            _context.SaveChanges();
            return inventoryId;
        }

        public int Update(Inventory item)
        {
            var inventory = _context.Inventory.Find(item.InventoryId);
            if (inventory is null)
                return 0;
            inventory.ItemName = item.ItemName;
            inventory.Measurement = item.Measurement;
            inventory.Price = item.Price;
            inventory.Quantity = item.Quantity;
            inventory.VendorID = item.VendorID;
            inventory.ModifiedBy = item.ModifiedBy;
            inventory.ModifiedDate = item.ModifiedDate;
            _context.Update(inventory);
            _context.SaveChanges();
            return item.InventoryId;
        }
    }
}
