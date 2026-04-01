using System.IdentityModel.Tokens.Jwt;
using CondoProj.Entities;
using CondoProj.Interfaces;
using CondoProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CondoProj.Services
{
    public class AuthService : IAuthService
    {
        private readonly CondoDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthService(CondoDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<User?> RegisterAsync(UserDto request)
        {
            bool existsUser = await _dbContext.Users.AnyAsync(u => u.Username == request.Username);

            if (existsUser)
            {
                return null;
            }

            var user = new User();

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;

            _dbContext.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        //public Task<string?> LoginAsync(UserDto request)
        //{
        //    if (user.Username != request.Username)
        //    {
        //        return BadRequest("User Not Found");
        //    }

        //    var verifiedHashedPassword = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password);
        //    if (verifiedHashedPassword == PasswordVerificationResult.Failed)
        //    {
        //        return BadRequest("Wrong Password");
        //    }

        //    string token = CreateToken(user);
        //    return Ok(token);
        //}
    }
}
