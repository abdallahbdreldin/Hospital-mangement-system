using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public interface ICalcTimeHelper
    {
        string GetDate(DayOfWeek DayOfWeek);
        List<WorkScheduleTimeDto> calc(DayOfWeek Day, string id);
        bool checkStatus(string id, TimeSpan time, DayOfWeek Day);
    }
}
