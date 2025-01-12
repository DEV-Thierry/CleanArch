using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserDTO userDTO);

        Task<User> GetUserByNameAsync(string firstName);

        Task<List<User>> GetAllUsersAsync();

        Task<User> UpdateUserAsync(UserUpdateDTO user);

        Task<User> DeleteUserAsync(Guid id);
    }
}