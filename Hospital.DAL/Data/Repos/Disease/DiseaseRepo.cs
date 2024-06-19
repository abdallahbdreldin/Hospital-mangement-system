using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class DiseaseRepo : GenericRepos<Disease>, IDiseaseRepo
    {
        public DiseaseRepo(HopitalContext db) : base(db)
        {
        }
    }
}
