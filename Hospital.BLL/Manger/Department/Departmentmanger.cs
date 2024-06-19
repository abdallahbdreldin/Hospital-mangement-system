using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class Departmentmanger : IDepartmentmanger

    {
        private readonly IDepartmentRepo db;

        public Departmentmanger(IDepartmentRepo db)
        {
            this.db = db;
        }

        public List<DepartmentDtos> GetAllDepartment()
        {
            List<Department> result = db.GetAll(e => e.Doctors).ToList();

            return result.Select(h => new DepartmentDtos
            {
                Id = h.Id,
                Name = h.Name,
                deptImage = h.deptImage,
                
                Description=h.Description,
                doctors = h.Doctors.Select(d => new DoctoreForDept { Id = d.Id, Name = d.Name,ProfilePic=d.ProfilePic,departmentname=d.Department.Name}).ToList()

            }).ToList();
        }

        public DepartmentDtos getDeptById(int id)
        {
            Department? result = db.GetByIdWithInclude(department => department.Id == id, x => x.Doctors);
            if (result == null)
            {

                return null;
            }

            return new DepartmentDtos
            {
                Id = result.Id,
                Name = result.Name,
                deptImage = result.deptImage,
                Description = result.Description,
                doctors = result.Doctors.Select(d => new DoctoreForDept
                {
                    Id = d.Id,
                    Name = d.Name,
                    ProfilePic = d.ProfilePic,
                    departmentname = d.Department.Name
                }).ToList(),
            };
        }
    }
}
