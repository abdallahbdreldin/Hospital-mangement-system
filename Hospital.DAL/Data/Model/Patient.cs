using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class Patient
    {
        public string id { get; set; } = string.Empty;
        public string name { get; set; }
        public int phoneNumber { get; set; }

        public string email { get; set; } = string.Empty;
        public DateTime birthDate { get; set; }

        public string address { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<Disease> Disease { get; set; } = new HashSet<Disease>();
    }
}
