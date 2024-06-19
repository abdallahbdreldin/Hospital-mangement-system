using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyPolicyDoctorTokenController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "DoctorPolicy")]
        [Route("verifyPolicyDoctor")]

        public ActionResult VerifyToken()
        {
            var idOfCurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var RoleOfCurrentUser = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new
            {
                idOfCurrentUser = idOfCurrentUser,
                RoleOfCurrentUser = RoleOfCurrentUser,  // Doctor 



            });
        }
    }
}
