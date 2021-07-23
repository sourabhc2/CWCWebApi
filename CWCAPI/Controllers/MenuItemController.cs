using AutoMapper;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models;
using CWC.Models.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
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
    public class MenuItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IManageMenuItem _menuitemRepo;
        public MenuItemController(IMapper mapper, IManageMenuItem menuitemRepo)
        {
            _mapper = mapper;
            _menuitemRepo = menuitemRepo;
        }
        [HttpPost]
        [Route("add")]

        public IActionResult AddInventory(MenuItemReqDTOs model)
        {

            var menuitems = _mapper.Map<Menuitems>(model);

            menuitems.AddedBy = HttpContext.User.FindFirst("name").Value;
            if (HttpContext.User.FindFirst("role").Value == "1")
            menuitems.ItemApprvFrmSuperAdm = true;
            var added = _menuitemRepo.Add(menuitems,model.VendorID);
            return Ok(new
            {
                success = added > 0 ? true : false
            });
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateMenuItem(MenuItemReqDTOs model)
        {
            var menuitem = _mapper.Map<Menuitems>(model);
         
            var updated = _menuitemRepo.Update(menuitem,model.VendorID);

            return Ok(new
            {
                success = updated > 0 ? true : false
            });
        }
        [HttpGet]
        [Route("gets/{status}")]
        public IActionResult GetMenuItems(int status)
        {
            var menuitems = _menuitemRepo.Gets(status);
            return Ok(new
            {
                data = menuitems
            });
        }
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetMenuItem(int id)
        {

            var menuitem = _menuitemRepo.Get(id);

            return Ok(new
            {
                data = menuitem
            });
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult RemoveInventiry(int id)
        {
            string name = HttpContext.User.FindFirst("name").Value;
            var deleted = _menuitemRepo.Remove(id, name);

            return Ok(new
            {
                success = deleted 
            });
        }
        [HttpPost]
        [Route("Apprv/{id}")]
        public IActionResult ApprvMenuItem(int id)
        {
            var Apprv = _menuitemRepo.Apprv(id);

            return Ok(new
            {
                success = Apprv
            });
        }
    }
}
