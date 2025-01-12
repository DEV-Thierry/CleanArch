using Application.Interfaces;
using Application.UseCases;
using CleanArch.Infrastructure.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(user == null) throw new Exception("usuario com o id fornecido nao foi encontrado ");

            user.Ativo = false;
            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByNameAsync(string firstName)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}