using CondoProj.Entities;
using CondoProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace CondoProj.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        //Task<string?> LoginAsync(UserDto request);

    }
}
