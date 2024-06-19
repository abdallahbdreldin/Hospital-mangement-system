using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class doctorschedulesDto
    {
        public string Day { get; set; }
        public List<WorkScheduleTimeDto> WorkScheduleTime { get; set; }
    }
}
