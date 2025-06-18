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
    public class FreeSickRepository : IFreeSickRepository
    {
        private readonly DataContext _context;

        public FreeSickRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FreeSick>> GetAllAsync()
        {
            return await _context.FreeSicks.ToListAsync();
        }

        public async Task<FreeSick?> GetByIdAsync(int id)
        {
            return await _context.FreeSicks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FreeSick> AddAsync(FreeSick freeSick)
        {
            await _context.FreeSicks.AddAsync(freeSick);
            return freeSick;
        }

        public async Task<FreeSick> UpdateAsync(FreeSick freeSick)
        {
            var existingFreeSick = await GetByIdAsync(freeSick.Id);
            if (existingFreeSick is null)
            {
                throw new Exception("FreeSick not found");
            }
            existingFreeSick.FreeDate = freeSick.FreeDate;
            return existingFreeSick;
        }

        public async Task DeleteAsync(int id)
        {
            var existingFreeSick = await GetByIdAsync(id);
            if (existingFreeSick is not null)
            {
                _context.FreeSicks.Remove(existingFreeSick);
            }
        }
    }
}
