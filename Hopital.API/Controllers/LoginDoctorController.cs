using Hospital.BLL;
using Hospital.BLL.Dtos;
using Hospital.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDoctorController : ControllerBase
    {

        private readonly UserManager<AddOnApplicationUser> userManager;
        private readonly IConfiguration configration;
        private readonly IDoctorRepo doctorRepo;

        public LoginDoctorController(UserManager<AddOnApplicationUser> userManager,
            IConfiguration configration ,
            IDoctorRepo doctorRepo)
        {
            this.userManager = userManager;
            this.configration = configration;
            this.doctorRepo = doctorRepo;
        }




        #region Clean Register

        [HttpPost]
        [Route("CleanRegister")]
        public async Task<ActionResult> CleanRegister(DoctorRegisterDto doctorRegisterDto)
        {
            var newUser = new AddOnApplicationUser
            {
                FirstName =doctorRegisterDto.firtsname,
                LastName=doctorRegisterDto.lastname,
                DoctorDescription = doctorRegisterDto.description,
                DoctorPrice = doctorRegisterDto.price,
                DoctorProfile=doctorRegisterDto.ProfilePic,
                DoctorDepartmentId=doctorRegisterDto.DepartmentId,  
                UserName=doctorRegisterDto.email,
                gender=doctorRegisterDto.gender,
                mobileNumber=doctorRegisterDto.mobileNumber,
                watingList=doctorRegisterDto.watingList,  
                Email= doctorRegisterDto.email,

            };

            var resultCreationUser = await userManager.CreateAsync(newUser, doctorRegisterDto.DoctorPassword);

            if (!resultCreationUser.Succeeded)
            {
                return BadRequest(resultCreationUser.Errors);
            }

            List<Claim> claimsList = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, newUser.Id),
        new Claim("UserName", newUser.UserName),
        new Claim("Password", newUser.PasswordHash),
        new Claim(ClaimTypes.Role, "Doctor"),
    };
            await userManager.AddClaimsAsync(newUser, claimsList);
            Doctor doctor = new Doctor();
            doctor.Id = newUser.Id;  
            doctor.Name = newUser.FirstName + " "+ newUser.LastName;
            doctor.description = newUser.DoctorDescription;
            doctor.price = newUser.DoctorPrice;
            doctor.DepartmentID = newUser.DoctorDepartmentId;
            doctor.gender = newUser.gender; 
            doctor.ProfilePic=newUser.DoctorProfile;
            doctor.watingList= newUser.watingList;  
            doctor.mobileNumber= newUser.mobileNumber;  
            doctorRepo.SaveChanges(doctor);
            return StatusCode(StatusCodes.Status201Created);
        }

        #endregion






        [HttpPost]
        [Route("CleanLogin")]
        public async Task<ActionResult<TokenDto>> CleanLogin(CredentialsDto credentials)
        {
            AddOnApplicationUser? user = await userManager.FindByNameAsync(credentials.userName);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, credentials.password);
            if (!isPasswordCorrect)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            #region جهز ال Claims

            var claimsList = await userManager.GetClaimsAsync(user);


            #endregion

            #region تحهيز ال Algorithm

            // Download Pakage Microsowft.IndentityModel.Tokens

            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            #endregion

            #region جهز ال secretKey

            string? secretKey = configration.GetValue<string>("secretKey");



            //=> 1-  Convert SecretKey from string to Array of Bytes => ASCII code

            var KeyInBytes = Encoding.ASCII.GetBytes(secretKey);

            //=> 2-  Convert seecretKey from Array of bytes to Object 
            var Key = new SymmetricSecurityKey(KeyInBytes);


            // => 3- take secretkey as a Object and algorithm
            var secretKeyPlusAlgorithm = new SigningCredentials(Key, algorithm);

            #endregion

            #region GenerateJwt

            // Download Pakage Microsowft.IndentityModel.Tokens.Jwt

            var newJwt = new JwtSecurityToken
                (
                    claims: claimsList,
                    signingCredentials: secretKeyPlusAlgorithm,
                    expires: DateTime.Now.AddMinutes(10)
                );

            //We Can return a new Object from Token in Dto as String

            // this Object he resposible to write the token 
            var tokenHandler = new JwtSecurityTokenHandler();
            return new TokenDto
            {
                Token = tokenHandler.WriteToken(newJwt),
            };


            #endregion

        }

    }
}
