
using Hospital.BLL;
using Hospital.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Hopital.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region defult
            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            builder.Services.AddDbContext<HopitalContext>(options =>

            options.UseSqlServer(builder.Configuration.GetConnectionString("hospital"))
              );

            #region Inject Service ASP Identity (must be before Authentication) to be able to use User Manager

            // you can add an options to make a regulation when the program add a new User

            builder.Services.AddIdentity<AddOnApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                

            })
                            .AddEntityFrameworkStores<HopitalContext>();


            #endregion

            #region Authentication

            builder.Services
                   .AddAuthentication(options =>
                   {
           //هي بتقول ان على اي اساس البرنامج هيعملك اوثينتيكشن  
                       options.DefaultAuthenticateScheme = "xyz";

           // هي اللي بتقول البرنامج يتصرف ازاي لو الريكويست مش اوثوريز
           // اعمل معاك ايه لو انت طلعت مش اوثنتيكاتد
                       options.DefaultChallengeScheme = "xyz";
                   })
                            .AddJwtBearer("xyz", options =>
                            {
                                string? secretKey = builder.Configuration.GetValue<string>("secretKey");
                                var KeyInBytes = Encoding.ASCII.GetBytes(secretKey);
                                var Key = new SymmetricSecurityKey(KeyInBytes);

                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    IssuerSigningKey = Key,
                                    ValidateIssuer = false,
                                    ValidateAudience = false,
                                };
                            });

            #endregion

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("DoctorPolicy", p => p.RequireClaim(ClaimTypes.Role, "Doctor"));
            });


            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IHopitalRepo, HospitalRepo>();
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<IHospitalManger, HospitalManger>();
            builder.Services.AddScoped<IBookingRepo, BookingRepo>();
            builder.Services.AddScoped<IDepartmentmanger, Departmentmanger>();
            builder.Services.AddScoped<IDoctorManger, DoctorManger>();
            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddScoped<IDiseaseRepo, DiseaseRepo>();
            builder.Services.AddScoped<IDoctorWorkTime, DoctorWorkTime>();       
            builder.Services.AddScoped<ICalcTimeHelper, CalcTimeHelper>();
            builder.Services.AddScoped<IPatientmanger, PatientManger>();


            builder.Services.AddCors(option =>
            {
                option.AddPolicy("AllowPolice", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });


            #region build
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowPolice");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}