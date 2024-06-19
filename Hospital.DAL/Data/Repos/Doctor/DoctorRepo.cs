using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class DoctorRepo : GenericRepos<Doctor>, IDoctorRepo
    {
        private readonly HopitalContext db;

        public DoctorRepo(HopitalContext db) : base(db){
            this.db = db;
        }
        public List<Doctor>? GetFullData()

        {
            var result = db.doctors.Include(d => d.Department).ThenInclude(d => d.Hosptial).ToList();
            return result;
        }
        public Doctor? GetFullDataByID(string id)
        {
            var result = db.doctors.Include(d => d.Department).ThenInclude(d => d.Hosptial).FirstOrDefault(d => d.Id == id);
            return result;
        }
        public List<Doctor>? searchByName(string doctorName)
        {
            var result = db.doctors.Include(d => d.Department).ThenInclude(d => d.Hosptial).Where(doc => doc.Name.StartsWith(doctorName)).ToList();

            if (result == null)
            {
                return null;

            }
            return result;

        }
        public async void SaveChanges(Doctor doctor)
        {
            
                db.Add(doctor);
                await db.SaveChangesAsync();
            

        }
    }
}
