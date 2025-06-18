using Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IHourService
    {
        Task<IEnumerable<Hour>> GetListAsync();
        Task<Hour?> GetByIdAsync(int id);
        Task<Hour> AddAsync(Hour Hour);
        Task<Hour> UpdateAsync(Hour Hour);
        Task DeleteAsync(int id);
    }
}