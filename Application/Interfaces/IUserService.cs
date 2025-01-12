using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserDTO userDTO);

        // Task<User> GetUserByIdAsync(int id);

        // Task<IEnumerable<User>> GetAllUsersAsync();

        // Task<User> UpdateUserAsync(User user);

        // Task<User> DeleteUserAsync(int id);
    }
}