using Core.Dtos;
using Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetListAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(int id);
        //Task<UserDto> ValidateUserAsync(string username, string password);
    }
}