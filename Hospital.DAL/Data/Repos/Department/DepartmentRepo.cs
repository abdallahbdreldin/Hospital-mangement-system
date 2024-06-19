using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class DepartmentRepo : GenericRepos<Department>, IDepartmentRepo
    {
        private readonly HopitalContext db;

        public DepartmentRepo(HopitalContext db) : base(db)
        {
            this.db = db;
        }


        public Department? SearchByName(string name)
        {
            var result = db.Department.Include(dep => dep.Doctors).Where(data => data.Name == name).FirstOrDefault();

            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

    }
}
