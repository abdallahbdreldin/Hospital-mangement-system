using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class Booking
    {
        public Guid Id { get; set; }

        public DateTime DateOfBook { get; set; }

        public TimeSpan TimeOfBook { get; set; }
        public DateTime PatSubmitDate { get; set; }
        public TimeSpan PatSubmitTime { get; set; }
        public string? PatName { get; set; }
        public string? Email { get; set; }
        public bool? status { get; set; }
        public int number { get; set; }
        public string patId { get; set; }
        public Patient? patient { get; set; }

        public string DoctorId { get; set; }
        
        public Doctor? Doctor { get; set; }
    }
}
