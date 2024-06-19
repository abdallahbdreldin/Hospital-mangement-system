using Hospital.BLL;
using Hospital.BLL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController:ControllerBase
    {
        private readonly IPatientmanger db;

        public PatientController(IPatientmanger db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("patientdetails/{id}")]
      
        public ActionResult<PatientDto> GetDetails(string id)
        {
            var result = db.GetPatientByID(id);
            if(result == null) { return BadRequest(); }

            return Ok(result);  

        }

        [HttpPost]
        public ActionResult addDisease(PostDiseaseDto ds)
        {
            db.PostOfDoctor(ds);
            return Ok();

        }



    }

}
