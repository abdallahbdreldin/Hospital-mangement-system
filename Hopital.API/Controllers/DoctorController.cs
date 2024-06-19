using Hospital.BLL;
using Hospital.BLL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hopital.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    
    public class DoctorController:ControllerBase

    {
        private readonly IDoctorManger db;

        public DoctorController(IDoctorManger db)
        {
            this.db = db;
        }


        [HttpGet]
        public ActionResult<List<DoctorReadDto>> GetAllDoctor() {
        
        return db.GetAllDoctor();   
        
        }

        [HttpGet]
        [Route("doctordetails/{id}")]
        public ActionResult <DoctorReadDto> getDoctor(string id)
        {
            var result = db.GetDoctorById(id);
            if(result == null)
            {
                return NotFound();

            }
            return result;
        }
        [HttpGet]
        [Route("doctorbookinday/{id}")]
        public ActionResult<List<DoctorBookIndayDto>> getDoctorBookInDay(string id)
        {
            var result = db.GetDoctorBookInDay(id);
            if (result == null)
            {
                return NotFound();
            }

            return result;

        }



    }
}
