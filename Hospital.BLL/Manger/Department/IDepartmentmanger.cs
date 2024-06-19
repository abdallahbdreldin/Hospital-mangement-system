using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public interface IDepartmentmanger
    {

        List<DepartmentDtos> GetAllDepartment();
        DepartmentDtos getDeptById(int id);
    }
}
