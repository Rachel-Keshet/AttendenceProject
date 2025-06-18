using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IUserRepository Users { get; }

        public IHourRepository Hours { get; }

        public IFreeSickRepository FreeSicks { get; }

        public RepositoryManager(DataContext context, IUserRepository userRepository, IHourRepository hourRepository, IFreeSickRepository freeSickRepository)
        {
            _context = context;
            Users = userRepository;
            Hours= hourRepository;
            FreeSicks = freeSickRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
