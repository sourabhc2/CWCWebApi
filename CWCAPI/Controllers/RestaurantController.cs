using AutoMapper;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models.RequestDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IManageRestaurant _restaurantRepo;
        private readonly IManageMenuItem _menuItemRepo;
        public RestaurantController(IMapper mapper, IManageRestaurant restaurantRepo, IManageMenuItem menuItemRepo)
        {
            _mapper = mapper;
            _restaurantRepo = restaurantRepo;
            _menuItemRepo = menuItemRepo;
        }
        [HttpPost]
        [Route("CreateOrder")]

        public IActionResult  CreateOrder([FromBody]OrderReqDTOs order)
        {

            var orderdetails = _mapper.Map<Order>(order);
            var orderitems = _mapper.Map<List<OrderItems>,List<OrderItem>>(order.OrderItems);

            var orderStatus = _restaurantRepo.CreateOrder(orderdetails, orderitems);
            return Ok(new
            {
                success = orderStatus > 0 ? true : false
            });
        }
        [HttpGet]
        [Route("CreateBill")]
        public IActionResult CreateBill(int orderid)
        {
           

            var bill= _restaurantRepo.CreateBill(orderid);

            return Ok(new
            {
                data = bill
            });
        }
        [HttpPost]
        [Route("CancelOrder")]
        public IActionResult CancelOrder(int orderid)
        {
            var orderstatus = _restaurantRepo.CancelOrder(orderid);
            return Ok(new
            {
               Success = orderstatus
            });
        }
 
        [HttpPost]
        [Route("AddOrderItems")]
        public IActionResult AddOrderItems(OrderItem item)
        {
            var orderitem = _mapper.Map<Order>(item);
            var itemstatus = _restaurantRepo.AddOrderItems(item);

            return Ok(new
            {
                success = itemstatus>0?true:false
            });
        }

    }
}
