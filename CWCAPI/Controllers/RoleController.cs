using AutoMapper;
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
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRolesRepo _roleRepo;
        public RoleController(IMapper mapper, IRolesRepo roleRepo)
        {
            _mapper = mapper;
            _roleRepo = roleRepo;
        }
        [HttpPost]
        [Route("add")]

        public IActionResult AddRoles(string role)
        {
            var added = _roleRepo.AddRoles(role);
            return Ok(new
            {
                success = added > 0 ? true : false
            });
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateRoles(int id, string role)
        {

            var updated = _roleRepo.UpdateRoles(id,role);

            return Ok(new
            {
                success = updated > 0 ? true : false
            });
        }
        [HttpGet]
        [Route("gets")]
        public IActionResult GetRoles()
        {
            var roles = _roleRepo.GetRoles();
            return Ok(new
            {
                data = roles
            });
        }
        [HttpDelete]
        [Route("delete/{Id}")]
        public IActionResult RemoveRoles(int Id)
        {

            var deleted = _roleRepo.RemoveRoles(Id);

            return Ok(new
            {
                success = deleted > 0 ? true : false
            });
        }
        [HttpPost]
        [Route("AddUserRoles")]
        public IActionResult AssignRolesToUser([FromBody] UserRolesReqDTOs model)
        {
            var added = _roleRepo.AssignRolesToUser(model.UserId,model.UserRoles);
            return Ok(new
            {
                success = added > 0 ? true : false
            });
        }

        [HttpPost]
        [Route("RemoveUserRoles")]
        public IActionResult  RemoveUserRoles([FromBody] UserRolesReqDTOs model)
        {
            var deleted = _roleRepo.AssignRolesToUser(model.UserId, model.UserRoles);
            return Ok(new
            {
                success = deleted > 0 ? true : false
            });
        }

        [HttpGet]
        [Route("GetsUserRoles/{Id}")]
        public IActionResult GetUserRoles(int Id)
           {
            var userRoles = _roleRepo.GetUserRoles(Id);
            return Ok(new
            {
                data = userRoles
            });
        }
    }
}
