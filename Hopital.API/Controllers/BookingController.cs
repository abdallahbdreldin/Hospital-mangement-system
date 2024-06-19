
using Hospital.BLL;
using Hospital.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        private readonly IDoctorWorkTime db;


        public BookingController(IDoctorWorkTime db )
        {
            this.db = db;
        
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<doctorschedulesDto>> GetDoctorAvaliableTime(string id)
        {
            var doctortime = db.GetAvailableTimeSlots(id);

            if (doctortime == null)

            {
                return NotFound();

            }
            return doctortime;



        }
       
        [HttpPost]
        public ActionResult Add(BookingDto booking)
        {

           var result= db.AddBooking(booking);
            if (!result)
            {
                return BadRequest(new BadRequestObjectResult(new { message = "this booking is already booked by another user " }));
            }
         
            else
            {
                return Ok();
            }
        }

    }
}
