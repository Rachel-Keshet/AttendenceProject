using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Hour
    {
        public int Id { get; set; }

        public DateTime AttendDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
