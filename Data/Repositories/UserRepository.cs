using Core.entities;
using Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var existingUser = await GetByIdAsync(user.Id);
            if (existingUser is null)
            {
                throw new Exception("User not found");
            }
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
            return existingUser;
        }

        public async Task DeleteAsync(int id)
        {
            var existingUser = await GetByIdAsync(id);
            if (existingUser is not null)
            {
                _context.Users.Remove(existingUser);
            }
        }
    }
}