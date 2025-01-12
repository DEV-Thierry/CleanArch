using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _Service;

        public UserController(IUserService userService)
        {
            _Service = userService;
        }

        [HttpGet]
        public Task<List<User>> GetAllUsers()
        {
            return _Service.GetAllUsersAsync();
        }

        [HttpGet("{FirstName}")]
        public async Task<User> GetUserByName(string FirstName){
           return await _Service.GetUserByNameAsync(FirstName);
        }

        [HttpPost]
        public async Task<User> CreateUser(UserDTO user){
            return await _Service.CreateUserAsync(user);
        }

        [HttpDelete]
        public async Task<User> DeleteUser(Guid id){
            return await _Service.DeleteUserAsync(id);
        }
    }
}