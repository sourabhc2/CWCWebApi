using AutoMapper;
using CWC.DAL.Entity;
using CWC.DAL.Implementation;
using CWC.DAL.Repository;
using CWC.Models;
using CWC.Models.RequestDTOs;
using CWCAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CWCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Role.SuperAndAdmin)]
    public class VendorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IManageVendors _vendorRepo;
        public VendorsController(IMapper mapper, IManageVendors vendorRepo)
        {
            _mapper = mapper;
            _vendorRepo = vendorRepo;
        }

        [HttpPost]
        [Route("add")]       
        public async Task<IActionResult> AddNewVendor(VendorsReqDto model)
        {
           
            var vendor = _mapper.Map<Vendors>(model);
            model.AddedBy=  HttpContext.User.FindFirst("name").Value;
            var role = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value;
            if ( role==Role.SuperAdmin)
            model.IsNewApproved = true;
            
            var vendorStatus = await _vendorRepo.AddNewVendor(vendor);

            return Ok(new
            {
                success =vendorStatus.Item2,
                Id = vendorStatus.Item1
            });
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateVendor(VendorsReqDto model)
        {

            var vendor = _mapper.Map<Vendors>(model);
            var vendorStatus = await _vendorRepo.UpdateVendorDetails(vendor);

            return Ok(new
            {
                success = vendorStatus,
               
            });
        }
        [HttpGet]
        [Route("gets")]
        public async Task<IActionResult> GetVendorList([FromQuery]PagingParameters page)
        {

            var vendorList = await _vendorRepo.GetVendorList(page.PageNumber,page.PageSize);

            return Ok(vendorList);
        }
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetVendorDetailsById(int id )
        {

            var vendor = await _vendorRepo.GetVendorDetailsById(id);

            return Ok(vendor);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteVendors(int id)
        {
            string name = HttpContext.User.FindFirst("name").Value;
           
            var vendorStatus = await _vendorRepo.DeleteVendors(id,name);

            return Ok(new
            {
                success = vendorStatus,

            });
        }
        [HttpDelete]
        [Route("approve")]
        public async Task<IActionResult> ApprNewVendors(int id)
        {

            var vendorStatus = await _vendorRepo.ApprNewVendors(id);

            return Ok(new
            {
                success = vendorStatus,

            });
        }
    }
}
