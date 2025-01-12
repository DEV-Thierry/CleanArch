using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
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

        public async Task<User> CreateUserAsync(UserDTO userDTO)
        {
            var user = User.Create(
                userDTO.FirstName,
                userDTO.LastName,
                userDTO.Email,
                userDTO.Password
            );

            return await _userRepository.AddUserAsync(user);
        }

        public async Task<User> GetUserByNameAsync(string firstName)
        {
            return await _userRepository.GetUserByNameAsync(firstName);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }

}