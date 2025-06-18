using Core.entities;
using Core.Interface;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HourService : IHourService
    {
        private readonly IHourRepository _HourRepository;

        public HourService(IHourRepository HourRepository)
        {
            _HourRepository = HourRepository;
        }

        public async Task<IEnumerable<Hour>> GetListAsync()
        {
            return await _HourRepository.GetAllAsync();
        }

        public async Task<Hour?> GetByIdAsync(int id)
        {
            return await _HourRepository.GetByIdAsync(id);
        }

        public async Task<Hour> AddAsync(Hour Hour)
        {
            return await _HourRepository.AddAsync(Hour);
        }

        public async Task<Hour> UpdateAsync(Hour Hour)
        {
            return await _HourRepository.UpdateAsync(Hour);
        }

        public async Task DeleteAsync(int id)
        {
            await _HourRepository.DeleteAsync(id);
        }
    }
}