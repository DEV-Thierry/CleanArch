using Application.Interfaces;
using Application.UseCases;
using CleanArch.Infrastructure.Context;
using Domain.Entities;

namespace CleanArch.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var response = _context.Users.Add(user);
            
            if(response == null) throw new Exception("Nao foi possivel cadastrar usuario");
            await _context.SaveChangesAsync();

            return response.Entity;
        }

        // public Task<User> DeleteUserAsync(int id)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<List<User>> GetAllUsersAsync()
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<User> GetUserByIdAsync(int id)
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<User> UpdateUserAsync(User user)
        // {
        //     throw new NotImplementedException();
        // }
    }
}