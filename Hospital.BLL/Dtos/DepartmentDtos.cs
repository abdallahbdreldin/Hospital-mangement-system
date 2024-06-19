using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class DepartmentDtos
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string deptImage { get; set; } = "";
        public string Description { get; set; } = "";
        public List<DoctoreForDept> doctors { get; set; } = new();
    }
}
