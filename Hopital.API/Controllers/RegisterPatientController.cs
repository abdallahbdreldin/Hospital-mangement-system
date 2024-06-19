using Hospital.BLL;
using Hospital.BLL.Dtos;
using Hospital.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hopital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPatientController : ControllerBase
    {
        private readonly UserManager<AddOnApplicationUser> userManager;
        private readonly IConfiguration configration;
        private readonly IPatientRepo patientRepo;

        public RegisterPatientController(UserManager<AddOnApplicationUser> userManager ,
            IConfiguration configration ,
            IPatientRepo patientRepo )
        {
            this.userManager = userManager;
            this.configration = configration;
            this.patientRepo = patientRepo;
        }

        #region Clean Register

        [HttpPost]
        [Route("CleanRegister")]
        public async Task<ActionResult> CleanRegister(RegisterDto registerDto)
        {
            var newUser = new AddOnApplicationUser
            {
                FirstName = registerDto.firstName,
                LastName = registerDto.lastName,
                gender = registerDto.gender,
                birthDate = registerDto.birthDate,
                Email = registerDto.email,
                UserName = registerDto.email, // Set the username here
                mobileNumber=registerDto.phoneNumber,
                address=registerDto.address
               
            };

            var resultCreationUser = await userManager.CreateAsync(newUser, registerDto.password);

            if (!resultCreationUser.Succeeded)
            {
                return BadRequest(resultCreationUser.Errors);
            }

            List<Claim> claimsList = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, newUser.Id),
        new Claim("UserName", newUser.UserName),
        new Claim("Password", newUser.PasswordHash),
        new Claim(ClaimTypes.Role, "Patient"),
    };
            await userManager.AddClaimsAsync(newUser, claimsList);

            Patient patient = new Patient();
            patient.id = newUser.Id;
            patient.name = newUser.FirstName + " " + newUser.LastName;
            patient.email = newUser.Email;
            patient.phoneNumber = newUser.mobileNumber;
            patient.address=newUser.address;    
            
            patientRepo.SaveChanges(patient);

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
