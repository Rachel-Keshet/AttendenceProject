using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        IHourRepository Hours { get; }
        IFreeSickRepository FreeSicks { get; }
         Task SaveAsync();
    }
}
