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
   public class ManageRestaurantRepo: IManageRestaurant
    {
        private readonly CWCContext _dbcontext;

        private readonly IManageMenuItem _menuItemRepo;
        private readonly IInventoryRepo _inventoryRepo;


        public ManageRestaurantRepo(CWCContext dbcontext, IManageMenuItem menuItemRepo, IInventoryRepo inventoryRepo)
        {

            _dbcontext = dbcontext;
            _menuItemRepo = menuItemRepo;
            _inventoryRepo = inventoryRepo;


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

        public int CreateOrder(Order order, List<OrderItem> Orderitems)
        {
            order.IsActive = true;
            order.CreatedDate = DateTime.Now;
            _dbcontext.Order.Add(order);
            _dbcontext.SaveChanges();
            var foodItem = new Menuitems();
            foreach (var item in Orderitems)
            {
                if (item.Id != 0)
                {
                    foodItem = _menuItemRepo.Get(item.Id);
                    item.FoodItemName = foodItem.Food_Item_Name;
                }
               
            }

            foreach (var item in Orderitems)
            {
               

                item.OrderId = order.Id;
                _dbcontext.OrderItem.Add(item);
                _dbcontext.SaveChanges();
            }
            var table = _dbcontext.TablesForBooking.Where(t => t.ID == order.TableID).FirstOrDefault();
            table.Status=false;
            _dbcontext.TablesForBooking.Update(table);
            _dbcontext.SaveChanges();
            return order.Id;

        }
        public BillResDTOs CreateBill(int orderid)
        {
            var bill = new BillResDTOs();
            var order = _dbcontext.Order.Where(o => o.Id == orderid&& o.IsActive==true).FirstOrDefault();
            bill.Customer_Name = order.Customer_Name;
            bill.OrderId = string.Concat("CWC",order.Id.ToString());
            bill.Phone = order.Phone;
            bill.TableID = order.TableID;

            var orderitem = (from o in _dbcontext.OrderItem.Where(o => o.Id == orderid)
                            orderby o.Id
                            select new OrderItems
                            {
                                FoodItemName = o.FoodItemName,
                                Price = o.Price,
                                Quantity = o.Quantity + o.FakeQuantity
                            }).ToList();
            bill.OrderItem = orderitem;
           double ?priceWithouttax = 0;
            foreach (var item in orderitem)
            {
                priceWithouttax = priceWithouttax + item.Price;
            }

            bill.PriceWithoutTax = priceWithouttax;
            bill.TotalPrice = (float)(priceWithouttax + (priceWithouttax / 100) * 20);
            var table = _dbcontext.TablesForBooking.Where(t => t.ID == order.TableID).FirstOrDefault();
            table.Status = false;
            _dbcontext.TablesForBooking.Update(table);
            _dbcontext.SaveChanges();
            return bill;



        }
        private bool UpdateInventoryUsage(int orderid,int billNo)
        {
 
            var order = _dbcontext.Order.Where(o => o.Id == orderid).FirstOrDefault();
           

            var orderitem = (from o in _dbcontext.OrderItem.Where(o => o.Id == orderid)
                             orderby o.Id
                             select new OrderItems
                             {
                                 FoodItemName = o.FoodItemName,
                                 Quantity = o.Quantity 
                             }).ToList();

            foreach (var item in orderitem)
            {
                var inventory = _dbcontext.Inventory.Where(i => i.ItemName == item.FoodItemName).FirstOrDefault();
                var inventoryUsage = new InventoryUsage();
                inventoryUsage.InventoryID = inventory.InventoryId;
                inventoryUsage.Used_Date = DateTime.Now.ToString();
                inventoryUsage.BillNo = billNo;
                inventoryUsage.Used_Qty = (double)item.Quantity ;
                inventoryUsage.Description = item.FoodItemName + "Sold at" + DateTime.Now.ToString();

            }

           

        }
        public int AddOrderItems(OrderItem item)
        {

            _dbcontext.OrderItem.Add(item);
            _dbcontext.SaveChanges();
            return item.Id;

            
        }
        public bool CancelOrder(int orderid)
        {
            var order=_dbcontext.Order.Where(o => o.Id == orderid).FirstOrDefault();
            order.IsActive = false;
            _dbcontext.SaveChanges();
            return true;

        }


    }
}
