using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Role { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Hour> Hours { get; set; }

        public List<FreeSick> FreeSick { get; set; }

    }
}
