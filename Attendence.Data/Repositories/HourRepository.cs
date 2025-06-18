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
    public class HourRepository : IHourRepository
    {
        private readonly DataContext _context;

        public HourRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hour>> GetAllAsync()
        {
            return await _context.Hours.ToListAsync();
        }

        public async Task<Hour?> GetByIdAsync(int id)
        {
            return await _context.Hours.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Hour> AddAsync(Hour hour)
        {
            await _context.Hours.AddAsync(hour);
            return hour;
        }

        public async Task<Hour> UpdateAsync(Hour hour)
        {
            var existingHour = await GetByIdAsync(hour.Id);
            if (existingHour is null)
            {
                throw new Exception("Hour not found");
            }
            existingHour.StartTime = hour.StartTime;
            existingHour.EndTime = hour.EndTime;
            return existingHour;
        }

        public async Task DeleteAsync(int id)
        {
            var existingHour = await GetByIdAsync(id);
            if (existingHour is not null)
            {
                _context.Hours.Remove(existingHour);
            }
        }
    }
}