using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if(user.FirstName == null) throw new Exception("Primeiro Nome Obrigatorio");

            return await _userRepository.AddUserAsync(user);
        }

        // public async Task<User> GetUserByIdAsync(int id)
        // {
        //     return await _userRepository.GetUserByIdAsync(id);
        // }

        // public async Task<IEnumerable<User>> GetAllUsersAsync()
        // {
        //     return await _userRepository.GetAllUsersAsync();
        // }

        // public async Task<User> UpdateUserAsync(User user)
        // {
        //     return await _userRepository.UpdateUserAsync(user);
        // }

        // public async Task<User> DeleteUserAsync(int id)
        // {
        //     return await _userRepository.DeleteUserAsync(id);
        // }
    }

}