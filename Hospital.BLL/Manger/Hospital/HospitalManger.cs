using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BLL
{
    public class HospitalManger : IHospitalManger
    {
        private readonly IHopitalRepo db;

        public HospitalManger(IHopitalRepo db)
        {
            this.db = db;
        }

        public List<HospitalDtos> GetAllDepartment()
        {
             List<Hosptial> result = db.GetAll(e => e.Departments).ToList();

            return result.Select(h => new HospitalDtos
            {
                Id = h.Id,  
                Name = h.Name,
                Address= h.Address,
                depatment=h.Departments.Select(d=>new DeptDtosForHospital{Id = d.Id, Name = d.Name, deptImage = d.deptImage ,Description = d.Description }).ToList()

            }).ToList();
            

        }

        public HospitalDtos? getDeptById(int id)
        {
         
            Hosptial? result = db.GetByIdWithInclude(Hosptial => Hosptial.Id == id, x => x.Departments);
            if(result == null) {
                return null;
            
            }

            return new HospitalDtos
            {
                Id = result.Id,
                Address = result.Address,
                Name = result.Name,
                depatment = result.Departments.Select(e => new DeptDtosForHospital
                {
                    Id = e.Id,
                    Name = e.Name,
                    deptImage = e.deptImage,
                    Description =e.Description
                   
                    
                }).ToList(),
            };

        }
    }
}
