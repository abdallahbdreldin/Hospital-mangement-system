

namespace Hospital.BLL;

public class DoctorRegisterDto
{

    public string firtsname { get; set; } = "";
    public string lastname { get; set; } = "";
   
    public string ProfilePic { get; set; } = "";
    public int DepartmentId { get; set; } 
    public string description { get; set; } = "";
    public int price { get; set; }
    public string gender { get; set; } = string.Empty;

    public string DoctorPassword { get; set; } = "";

    public string email { get; set; } = string.Empty;

    public int watingList { get; set; }
    public int mobileNumber { get; set; }
}
