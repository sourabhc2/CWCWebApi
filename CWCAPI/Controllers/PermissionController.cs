using AutoMapper;
using CWC.DAL.Repository;
using CWC.Models.RequestDTOs;
using CWCAPI.Permission;
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
    public class PermissionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPermissionRepo _permissionRepo;
        public PermissionController(IMapper mapper, IPermissionRepo permissionRepo)
        {
            _mapper = mapper;
            _permissionRepo = permissionRepo;
        }
        [HttpPost]
        [Route("add")]

        public IActionResult AddRolesClaims([FromBody]RoleClaimsReqDTOs model)
        {
            string claimtype = CustomClaimTypes.Permission;
            var added = _permissionRepo.AddRolesClaims(model.RoleId,model.ClaimValue,claimtype);
            return Ok(new
            {
                success = added > 0 ? true : false
            });
        }
        [HttpGet]
        [Route("gets/{roleid}")]
        public IActionResult GetRolesClaims(int roleid)
        {
            var roles = _permissionRepo.GetRolesClaims(roleid);
            return Ok(new
            {
                data = roles
            });
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult RemoveRolesClaims([FromBody] RoleClaimsReqDTOs model)
        {

            var deleted = _permissionRepo.RemoveRolesClaims(model.RoleId,model.ClaimValue);

            return Ok(new
            {
                success = deleted > 0 ? true : false
            });
        }
       
    }
}
