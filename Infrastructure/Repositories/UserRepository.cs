using System.Data.SqlTypes;
using Application.DTO;
using Application.Interfaces;
using Application.UseCases;
using Azure;
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

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.Where(x => x.Ativo).ToListAsync();
            return users;
        }

        public async Task<User> GetUserByNameAsync(string firstName)
        {
            if(firstName == null) throw new ArgumentNullException("firstName", "The user's first name is required");

            var user = await _context.Users.Where(x => x.FirstName == firstName && x.Ativo).FirstOrDefaultAsync();

            if(user == null) throw new SqlNullValueException("user was not found");

            return user;
        }

        public async Task<User> UpdateUserAsync(UserUpdateDTO user)
        {
            var response = await _context.Users.Where(x => x.Id == user.Id && x.Ativo).FirstOrDefaultAsync();

            if(response == null) throw new Exception("User was not found");

            response = UpdateResponseValues(response, user);
            
            _context.Users.Update(response);
            await _context.SaveChangesAsync();

            return response;
        }

        private User UpdateResponseValues(User response, UserUpdateDTO request){
            response.DataAlteracao = DateTime.Now;
            response.Email = string.IsNullOrWhiteSpace(request.Email)? response.Email : request.Email;
            response.FirstName = string.IsNullOrWhiteSpace(request.FirstName)? response.FirstName : request.FirstName;
            response.LastName = string.IsNullOrWhiteSpace(request.LastName)? response.LastName : request.LastName;

            return response;
        }
    }
}