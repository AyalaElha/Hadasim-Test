using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Repositories
{
    public interface IVaccineRepository
    {
        IEnumerable<Vaccine> GetVaccines();
        Vaccine GetVaccineById(int id);
        Vaccine AddVaccine(Vaccine vaccine);    
        Vaccine UpdateVaccine(int id, Vaccine vaccine);
        void DeleteVaccine(int id);
    }
}
