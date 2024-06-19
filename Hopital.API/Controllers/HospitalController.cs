using Hospital.BLL;

using Microsoft.AspNetCore.Mvc;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalManger db;

        public HospitalController(IHospitalManger db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<HospitalDtos>> GetAllHospital()
        {
            List < HospitalDtos > result = db.GetAllDepartment();

            return result;  
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<HospitalDtos> GetDetails(int id)
        {
            HospitalDtos? hospital = db.getDeptById(id);
            if (hospital == null)

            {
                return NotFound();

            }
            return hospital;


        }
    }
}
