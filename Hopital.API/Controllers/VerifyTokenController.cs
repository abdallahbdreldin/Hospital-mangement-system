using Hospital.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hopital.API.Controllers
{

    

    [Route("api/[controller]")]
    [ApiController]
    public class VerifyTokenController : ControllerBase
    {

       


        [HttpGet]
        // ده فيلتر مهمته ان لو اليوزر مش اوثوريز يقف هنا و يرجعله 401 Unauthorize
        [Authorize]
        [Route("verify")]
        // you can Get or verify the token throw Header 
        // Key : Value 
        // Authorization : Bearer (space) Token
        public ActionResult Data()
        {
            var idOfCurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(new
            {
              idOfCurrentUser=idOfCurrentUser,


             
            });
        }
    }
}
