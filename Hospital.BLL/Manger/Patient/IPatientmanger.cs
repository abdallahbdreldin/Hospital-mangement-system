using Hospital.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public interface IPatientmanger
    {
        PatientDto GetPatientByID(string id);
        void PostOfDoctor(PostDiseaseDto postdis);
    }
}
