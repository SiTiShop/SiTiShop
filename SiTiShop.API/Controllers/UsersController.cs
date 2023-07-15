using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiTiShop.Business.Service.UserService;
using SiTiShop.Data.Entities;

namespace SiTiShop.API.Controllers
{
    [Route("user/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _user;

        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string UserName, string Password, string FullName, string PhoneNumber, string Email)
        {
            Data.Models.ResultModel.ResultModel result = await _user.Register(UserName, Password, FullName, PhoneNumber, Email);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            Data.Models.ResultModel.ResultModel result = await _user.Login(UserName, Password);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("read-jwt")]
        public async Task<IActionResult> ReadJwt(string jwtToken, string secretkey, string issuer)
        {
            Data.Models.ResultModel.ResultModel result = await _user.ReadJWT(jwtToken, secretkey, issuer);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}