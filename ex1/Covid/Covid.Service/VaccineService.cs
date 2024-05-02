using Covid.Core;
using Covid.Core.Repositories;
using Covid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Service
{
    public class VaccineService:IVaccineService
    {
        private readonly IVaccineRepository _vaccineRepository;
        public VaccineService(IVaccineRepository vaccineRepository)
        {
            _vaccineRepository = vaccineRepository;
        }

        public Vaccine AddVaccine(Vaccine vaccine)
        {
            return _vaccineRepository.AddVaccine(vaccine);
           
        }

        public void DeleteVaccine(int id)
        {
            _vaccineRepository.DeleteVaccine(id);   
        }

        public IEnumerable<Vaccine> GetVaccines()
        {
           return _vaccineRepository.GetVaccines();  
        }

        public Vaccine GetVaccineById(int id)
        {
            return _vaccineRepository.GetVaccineById(id);
        }

        public Vaccine UpdateVaccine(int id, Vaccine vaccine)
        {
            return _vaccineRepository.UpdateVaccine(id, vaccine);   
        }
    }
}
