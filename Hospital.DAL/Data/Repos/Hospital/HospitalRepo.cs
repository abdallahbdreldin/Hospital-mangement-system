using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class HospitalRepo : GenericRepos<Hosptial>, IHopitalRepo
    {
        private readonly HopitalContext db;

        public HospitalRepo(HopitalContext db) : base(db)
        {
            this.db = db;
            this.db = db;
        }

        public Hosptial? SearchByName(string name)
        {
            var result = db.Hosptial.Include(hos => hos.Departments).ThenInclude(dept => dept.Doctors).Where(data => data.Name == name).FirstOrDefault();

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
