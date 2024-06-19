using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class DoctorWorkTime:IDoctorWorkTime
    {
        private readonly IDoctorRepo db;
        private readonly ICalcTimeHelper helper;
        private readonly IBookingRepo book;

        public DoctorWorkTime(IDoctorRepo db , ICalcTimeHelper helper,IBookingRepo book)
        {
            this.db = db;
            this.helper = helper;
            this.book = book;
        }

        public bool AddBooking(BookingDto booking)
        {
            if(helper.checkStatus(booking.DoctorId.ToString(), booking.TimeOfBook, booking.DateOfBook.DayOfWeek)==false)
            {
                return false;   

            }
            else
            {
                Booking newBooking = new Booking();

                newBooking.Id = Guid.NewGuid();
                newBooking.number = booking.number;
                newBooking.patId = booking.patId;
                newBooking.PatName = booking.PatName;
                newBooking.Email = booking.Email;
                newBooking.DateOfBook = booking.DateOfBook;
                newBooking.status = true;
                newBooking.PatSubmitDate = booking.PatSubmitDate;
                newBooking.DoctorId = booking.DoctorId;
                newBooking.TimeOfBook = booking.TimeOfBook;
                newBooking.PatSubmitTime = booking.PatSubmitTime;
                book.Add(newBooking);
                return true;

            }
           
            

        }

        public List<doctorschedulesDto> GetAvailableTimeSlots(string id)
        {
            var doctor = db.GetByIdWithInclude(d => d.Id == id, t => t.WorkSchedules);
            if (doctor == null) {
                return null;
            }

            var result= doctor.WorkSchedules.Select(work=>new doctorschedulesDto
            {
                Day = helper.GetDate(work.DayOfWeek),
                WorkScheduleTime = helper.calc(work.DayOfWeek, work.DoctorId),
            }).ToList();

            result = result.OrderBy(dto => DateTime.ParseExact(dto.Day.Substring(dto.Day.Length - 5), "dd-MM", null)).ToList();
            return result;

        }


       
    }
}
