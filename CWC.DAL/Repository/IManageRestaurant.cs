using CWC.DAL.Entity;
using CWC.Models.RequestDTOs;
using CWC.Models.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CWC.DAL.Repository
{
   public interface IManageRestaurant:IDisposable
    {

        public int CreateOrder(Order order,List<OrderItem> items);
        public BillResDTOs CreateBill(int orderid);
        public bool CancelOrder(int orderid);
        public int AddOrderItems(OrderItem item);
        //public int RemoveOrderItem(int orderitemid);


        //booking table 
        //public bool GetTablesAviliablity(string timeforbooking);
        //public bool BookingTable(string timeforbooking);
        //public bool AdvancedBookingofTable(int tableid ,string timeforbooking);



    }
}
