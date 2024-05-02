using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Services
{
    public interface IVaccineService
    {
        IEnumerable<Vaccine> GetVaccines();
        Vaccine GetVaccineById(int id);
        Vaccine AddVaccine(Vaccine vaccine);
        Vaccine UpdateVaccine(int id, Vaccine vaccine);
        void DeleteVaccine(int id);

    }
}
