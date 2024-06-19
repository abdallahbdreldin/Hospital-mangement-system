using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class Doctor
    {
        public string Id { get; set; }
        public string Name { get; set; } = "";
        public string ProfilePic { get; set; } = "";  
        public string description { get; set; } = "";
        public int price { get; set; }
        public string gender { get; set; } = "";
        public int watingList { get; set; } 
        public int mobileNumber { get; set; }
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
        public   ICollection<WorkSchedule> WorkSchedules { get; set; } = new HashSet<WorkSchedule>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}
