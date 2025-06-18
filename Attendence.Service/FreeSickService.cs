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
    public class FreeSickService : IFreeSickService
    {
        private readonly IFreeSickRepository _FreeSickRepository;

        public FreeSickService(IFreeSickRepository FreeSickRepository)
        {
            _FreeSickRepository = FreeSickRepository;
        }

        public async Task<IEnumerable<FreeSick>> GetListAsync()
        {
            return  await _FreeSickRepository.GetAllAsync();
        }

        public async Task<FreeSick?> GetByIdAsync(int id)
        {
            return await _FreeSickRepository.GetByIdAsync(id);
        }

        public async Task<FreeSick> AddAsync(FreeSick FreeSick)
        {
            return await _FreeSickRepository.AddAsync(FreeSick);
        }

        public async Task< FreeSick> UpdateAsync(FreeSick FreeSick)
        {
            return await _FreeSickRepository.UpdateAsync(FreeSick);
        }

        public async Task DeleteAsync(int id)
        {
            await _FreeSickRepository.DeleteAsync(id);
        }
    }
}