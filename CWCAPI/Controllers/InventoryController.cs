using AutoMapper;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models;
using CWC.Models.RequestDTOs;
using CWCAPI.Permission;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = Role.SuperAndAdmin)]
    public class InventoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInventoryRepo _inventoryRepo;
        public InventoryController(IMapper mapper, IInventoryRepo inventoryRepo)
        {
            _mapper = mapper;
            _inventoryRepo = inventoryRepo;
        }
        [HttpPost]
        [Route("add")]
        [Authorize(Permissions.Inventory.Create)]
        public IActionResult AddInventory(InventoryReqDTOs model)
        {

            var inventory = _mapper.Map<Inventory>(model);
            model.AddedDate = DateTime.Now;
            model.ModifiedBy = HttpContext.User.FindFirst("name").Value;          
            var added =  _inventoryRepo.Add(inventory);
            return Ok(new
            {
                success = added > 0 ? true : false
            });
        }
        [HttpPut]
        [Route("update")]
        [Authorize(Permissions.Inventory.Update)]
        public IActionResult UpdateInventory(InventoryReqDTOs model)
        {
            var inventory = _mapper.Map<Inventory>(model);
            inventory.ModifiedDate = DateTime.Now;
            inventory.ModifiedBy = HttpContext.User.FindFirst("name").Value;
            var updated =  _inventoryRepo.Update(inventory);

            return Ok(new
            {
                success = updated > 0 ? true : false
            });
        }
        [HttpGet]
        [Route("gets/{status}")]
        [Authorize(Permissions.Inventory.View)]
        public IActionResult GetInventories(int status)
        {
            var inventories=  _inventoryRepo.Gets(status);
            return Ok(new
            {
                data = inventories
            });
        }
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetInventory(int id)
        {

            var inventory = _inventoryRepo.Get(id);

            return Ok(new
            {
                data = inventory
            });
        }
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize(Permissions.Inventory.Delete)]
        public IActionResult RemoveInventiry(int id)
        {
            string name = HttpContext.User.FindFirst("name").Value;
            var deleted =  _inventoryRepo.Remove(id, name);

            return Ok(new
            {
                success = deleted > 0 ? true : false
            });
        }
    }
}
