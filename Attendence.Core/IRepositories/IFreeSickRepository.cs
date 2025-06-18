using Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
   public interface IFreeSickRepository
    {
        Task<IEnumerable<FreeSick>> GetAllAsync();

        Task<FreeSick?>GetByIdAsync(int id);

        Task< FreeSick> AddAsync(FreeSick FreeSick);

       Task< FreeSick> UpdateAsync(FreeSick FreeSick);

        Task DeleteAsync(int id);
    }
}
