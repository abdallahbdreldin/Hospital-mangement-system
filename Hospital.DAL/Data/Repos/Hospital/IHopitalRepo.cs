using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public interface IHopitalRepo:IGenericRepos<Hosptial>
    {
        Hosptial SearchByName(string name);
    }
}
