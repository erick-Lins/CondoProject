using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using CondoProj.Entities;
using CondoProj.Interfaces;
using CondoProj.Models;
using CondoProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CondoProj.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration, IAuthService service) : ControllerBase
    {
       
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {

            if (request == null)
                return BadRequest("Request is null");

            var result = await service.RegisterAsync(request);

            if (result == null)
                return BadRequest("The User already exists");

            return Ok(result);

        }

        //[HttpPost("login")]
        //public ActionResult<string> Login(UserDto request)
        //{
        //    if (request == null)
        //        return BadRequest("Invalid Login");

        //    var result = 

        //}


        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
