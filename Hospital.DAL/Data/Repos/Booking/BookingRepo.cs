using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class BookingRepo : GenericRepos<Booking>, IBookingRepo
    {
        public BookingRepo(HopitalContext db) : base(db)
        {
        }
    }
}
