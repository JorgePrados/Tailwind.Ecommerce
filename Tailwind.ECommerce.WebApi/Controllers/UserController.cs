using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tailwind.Ecommerce.Application.DTO;
using Tailwind.Ecommerce.Application.Interface;
using Tailwind.ECommerce.WebApi.Helpers;

namespace Tailwind.ECommerce.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly AppSettings _appSettings;
        public UserController(IUserServices userServices, IOptions<AppSettings> appSettings)
        {
            _userServices = userServices;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserDto userDto)
        {
            var user = await _userServices.Authenticate(userDto.userName, userDto.password);

            if (user.userId != 0)
            {
                user.token = BuildToken(user);
            }
            return Ok(user);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            var result = (await _userServices.Add(userDto));

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = (await _userServices.Delete(id));

            return Ok(result);
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get(int id)
        {
            var users = (await _userServices.Get(id));

            return Ok(users);
        }

        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = (await _userServices.GetAll());

            return Ok(users);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            int result = (await _userServices.Update(userDto));

            return Ok(result);
        }











        private string BuildToken(UserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDto.userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
