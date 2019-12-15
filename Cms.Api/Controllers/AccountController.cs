using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cms.Core.Domain;
using Cms.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cms.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        private List<User> users = new List<User>();
        public AccountController(IConfiguration configuration, ITokenService tokenService)
        {
            _configuration = configuration;
            _tokenService = tokenService;

            users.Add(new User { Id = 1, Username = "mori", Password = "1234" });
            users.Add(new User { Id = 2, Username = "bori", Password = "123456" });
            users.Add(new User { Id = 3, Username = "dori", Password = "12345678" });
        }

        [HttpGet("login")]
        public IActionResult Login(string username, string password)
        {
            //بررسی درست بودن یوزر و پسورد
            var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return BadRequest();
            }

            //ایجاد توکن
            var result = _tokenService.TokenGenerator(user.Id, user.Username);

            //ذخیره رفرش توکن
            // var user = users.FirstOrDefault(x => x.Username == username);
            //user.refreshToken = refreshToken;
            //context.SaveChange();

            return Ok(result);
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Authorized");
        }

        [HttpPost]
        public IActionResult Refresh(string token, string refreshToken)
        {
            //گرفتن اطلاعات درون توکن
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            
            //نام کاربری
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            //پیدا کردن کاربر و برابر نبودن رفرش توکن ورودی و رفرش توکن در دیتابیس
            // var user = _usersDb.Users.SingleOrDefault(u => u.Username == username);
            //if (user == null || user.RefreshToken != refreshToken) return BadRequest();

            //چک کردن ولید بودن رفرش توکن ثبت شده
            //if(user.ExpirationRefreshToken)<DateTime.Now)
            //return BadRequest();

            //تولید توکن جدید
            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            
            //تولید رفرش توکن جدید
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            //ذخیره رفرش توکن جدید
            //user.RefreshToken = newRefreshToken;
            //user.ExpirationRefreshToken=DateTime.Now.AddDays(5);
            //await _usersDb.SaveChangesAsync();

            return new ObjectResult(new
            {
                token = newJwtToken.token,
                expiration = newJwtToken.expiration,
                currentTime = DateTime.UtcNow,
                refreshToken = newRefreshToken
            });

           
        }
    }
}