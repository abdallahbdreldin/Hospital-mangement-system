using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class PatientRepo : GenericRepos<Patient>, IPatientRepo
    {
        private readonly HopitalContext db;

        public PatientRepo(HopitalContext db) : base(db)
        {
            this.db = db;
        }

      

        public async void SaveChanges(Patient patient)
        {
            db.Add(patient);
          await  db.SaveChangesAsync();
        }

 
    }
}
