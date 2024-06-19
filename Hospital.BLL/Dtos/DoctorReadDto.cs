using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL.Dtos
{
    public class DoctorReadDto
    {
        public string Id { get; set; } 
        public string Name { get; set; } = "";
        public string ProfilePic { get; set; } = "";
        public string Deptname { get; set; } = "";
        public string description { get; set; } = "";
        public int price { get; set; }
        public string Hosptialname { get; set; } = "";
    }
}
