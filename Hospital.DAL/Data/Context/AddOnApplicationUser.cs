
using Microsoft.AspNetCore.Identity;

namespace Hospital.DAL;

public  class AddOnApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string gender { get; set; } = string.Empty;  
    public DateTime birthDate { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string DoctorProfile { get; set; } = string.Empty;
    public int DoctorDepartmentId { get; set; }
    public string DoctorDescription { get; set; } = string.Empty;
    public int DoctorPrice { get; set; }
    public int watingList { get; set; }
    public int mobileNumber { get; set; }
    public string address { get; set; } = string.Empty;


}
