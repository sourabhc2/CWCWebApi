using AutoMapper;
using CWC.DAL.Entity;
using CWC.DAL.Repository;
using CWC.Models.RequestDTOs;
using CWC.Models.ResponseDTOs;
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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        public UserController(IMapper mapper, IUserRepo userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }
        [HttpPost]
        [Route("Auth")]
        [AllowAnonymous]
        public IActionResult Login(AuthReqDTOs model)
        {
            var user = _mapper.Map<Users>(model);
            var userResponse = _userRepo.ValidateUser(user);
            if (userResponse == null)
            {
                return Unauthorized();
            }
            var userDTO = _mapper.Map<AuthResDTOs>(userResponse);
            userDTO.Success = true;
            return Ok(userDTO);
        }
        [HttpPost("refreshtoken")]
        public IActionResult RefreshToken([FromBody] RefreshTokenReqDTOs item)
        {
            var user = _userRepo.RefreshToken(item);
            if (user is null)
            {
                return BadRequest(new { message = "Invalid client request" });
            }
            var userResDTO = _mapper.Map<AuthResDTOs>(user);
            userResDTO.Success = true;
            return Ok(userResDTO);
        }
    }
}
