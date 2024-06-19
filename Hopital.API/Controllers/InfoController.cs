using Hospital.BLL;
using Hospital.BLL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IDoctorManger db;

        public InfoController(IDoctorManger db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<DoctorReadDto>> GetAllDoctor()
        {

            return db.GetAllDoctor();

        }
        [HttpGet("search")]
        public ActionResult<List<DoctorReadDto>> SearchforDoctor(
           [FromQuery] string? hospital,
           [FromQuery] string? department,
           [FromQuery] string? doctorName
       )
        {
            var result = db.GetAllDoctor(hospital, department, doctorName);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

    }
}
