using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public interface IDoctorRepo:IGenericRepos<Doctor>
    {
        List<Doctor> searchByName(string doctorName);
        List<Doctor>? GetFullData();
        Doctor? GetFullDataByID(string id);
        public void SaveChanges(Doctor doctor);

    }
}
