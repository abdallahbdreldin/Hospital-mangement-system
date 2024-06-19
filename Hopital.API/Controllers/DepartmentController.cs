using Hospital.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController:ControllerBase
    {
        private readonly IDepartmentmanger db;

        public DepartmentController(IDepartmentmanger db)
        {
            this.db = db;
        }



        [HttpGet]
        public ActionResult<List<DepartmentDtos>> GetAllHospital()
        {
            List<DepartmentDtos> result = db.GetAllDepartment();

            return result;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<DepartmentDtos> GetDetails(int id)
        {
            DepartmentDtos? department = db.getDeptById(id);
            if (department == null)

            {
                return NotFound();

            }
            return department;


        }

    }
}
