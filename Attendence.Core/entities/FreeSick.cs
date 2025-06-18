using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entities
{
    public class FreeSick
    {
        public int Id { get; set; }
        public string? DayType { get; set; }
        public DateTime FreeDate { get; set; }

        public bool IsApproved { get; set; }
        public int UserId { get; set; }

        public User? User { get; set; }

    }
}
