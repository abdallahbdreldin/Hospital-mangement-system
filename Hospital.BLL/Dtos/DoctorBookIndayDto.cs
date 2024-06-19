using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class DoctorBookIndayDto
    {
        public string patID { get; set; }
        public string patName { get; set; } = "";
        public bool? status { get; set; }
        public string dateOfBook { get; set; } = "";
        public TimeSpan timeOfBook ;

    }
}
