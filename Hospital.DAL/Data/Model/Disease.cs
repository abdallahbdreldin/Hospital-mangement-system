using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class Disease
    {
        public Guid Id { get; set; }
        public string diseaseName { get; set; } = "";
        public string diseaseDetails { get; set; } = "";

        public string diseasetreatment { get; set; } = "";
        public string patientName { get; set; } = "";
        public string doctorName { get; set; } = "";
        public string PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
