using Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IFreeSickService
    {
        Task<IEnumerable<FreeSick>> GetListAsync();

        Task <FreeSick?> GetByIdAsync(int id);

        Task <FreeSick> AddAsync(FreeSick FreeSick);

        Task<FreeSick> UpdateAsync(FreeSick user);

        Task DeleteAsync(int id);
    }
}
