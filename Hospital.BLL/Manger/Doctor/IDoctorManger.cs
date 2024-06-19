using Hospital.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public interface IDoctorManger
    {
        List<DoctorReadDto> GetAllDoctor();
       DoctorReadDto GetDoctorById(string id);


        List<DoctorBookIndayDto> GetDoctorBookInDay(string id);
        List<DoctorReadDto> GetAllDoctor(string hopspitlaName, string DeptName, string Doctorname);

    }
}
