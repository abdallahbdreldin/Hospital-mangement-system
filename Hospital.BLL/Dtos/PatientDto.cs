using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class PatientDto
    {
        public string id { get; set; }
        public string? name { get; set; }
        public int phonenumber { get; set; }

        public string email { get; set; } = String.Empty;
        public DateTime birthDate { get; set; }

        public string address { get; set; } = String.Empty;
        public List<DiseaseDto> diseases { get; set; }=new ();   
    }
}
