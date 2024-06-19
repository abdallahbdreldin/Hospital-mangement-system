

using System.Collections.Specialized;

namespace Hospital.BLL.Dtos;

public class RegisterDto
{
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;

    public string email { get; set; } = string.Empty;   

    public int phoneNumber { get; set; } 
    
    public string gender { get; set; } = string.Empty;
    public string address { get; set; } = string.Empty;

    public string password { get; set; } = string.Empty;

    public string confirmPassword { get; set; } = string.Empty;


    public DateTime birthDate { get; set; }


}
