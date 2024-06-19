using Hospital.BLL.Dtos;
using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class PatientManger:IPatientmanger
    {
        private readonly IPatientRepo db;
        private readonly IDiseaseRepo diseaseDb;

        public PatientManger(IPatientRepo db,IDiseaseRepo diseaseDb )
        {
            this.db = db;
            this.diseaseDb = diseaseDb;
        }

        public PatientDto GetPatientByID(string id)
        {
            var result = db.GetByIdWithInclude(p => p.id == id, t => t.Disease);
            if (result == null) { return null; }
            return new PatientDto
            {
                id = result.id,
                name = result.name,
                phonenumber = result.phoneNumber,
                email = result.email,
                birthDate = result.birthDate,
                address = result.address,
                diseases = result.Disease.Select(d => new DiseaseDto { diseaseName = d.diseaseName, diseaseDetails = d.diseaseDetails, diseasetreatment = d.diseasetreatment, doctorName = d.doctorName }).ToList()
            };
        }







        void IPatientmanger.PostOfDoctor(PostDiseaseDto postdis)
        {
            Disease newDisease = new Disease
            {
                Id = Guid.NewGuid(),
                diseaseName = postdis.diseaseName,
                diseaseDetails = postdis.diseaseDetails,
                diseasetreatment = postdis.diseasetreatment,
                doctorName = postdis.doctorName,
                PatientID = postdis.Patientid,
                patientName = postdis.patientName


            };
            diseaseDb.Add(newDisease);

        }


    }
}
