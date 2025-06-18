using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public bool LastName { get; set; }
        public string Role { get; set; }

        public string Email { get; set; }

    }
}
