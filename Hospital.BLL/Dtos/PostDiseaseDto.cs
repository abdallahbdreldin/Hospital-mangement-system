using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Dtos
{
    public class PostDiseaseDto
    {
        public string diseaseName { get; set; } = "";
        public string diseaseDetails { get; set; } = "";

        public string diseasetreatment { get; set; } = "";
        public string Patientid { get; set; }
        public string patientName { get; set; } = "";
        public string doctorId { get; set; }
        public string doctorName { get; set; } = "";

    }
}
