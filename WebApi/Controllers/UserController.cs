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

        [HttpPost]
        public async Task<User> CreateUser(User user){
            return await _Service.CreateUserAsync(user);
        }
    }
}