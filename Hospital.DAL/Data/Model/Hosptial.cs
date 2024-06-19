using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class Hosptial
    {
        public int Id { get; set; }
        public string Address { get; set; } = "";
        public string Name { get; set; } = "";

        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
