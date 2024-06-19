using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public interface IPatientRepo:IGenericRepos<Patient>
    {
        public  void SaveChanges(Patient patient);

    }
}
