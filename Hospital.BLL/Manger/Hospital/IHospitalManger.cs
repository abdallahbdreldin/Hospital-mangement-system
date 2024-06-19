using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public interface IHospitalManger
    {
       List<HospitalDtos> GetAllDepartment();
        HospitalDtos getDeptById(int id);   
    }
}
