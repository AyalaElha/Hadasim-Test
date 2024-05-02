using Covid.Core;
using Covid.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Data.Repositories
{
   
    public class VaccineRepository: IVaccineRepository
    {
        private readonly DataContext _context;
        public VaccineRepository(DataContext context)
        {
            _context=context;   
        }

        public Vaccine AddVaccine(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
            return vaccine;
        }

        public void DeleteVaccine(int id)
        {
           _context.Vaccines.Remove(GetVaccineById(id));
           _context.SaveChanges();
        }

        public IEnumerable<Vaccine> GetVaccines()
        {
            return _context.Vaccines.Include(v=>v.Producer).Include(v => v.CovidDetails);
        }

        public Vaccine GetVaccineById(int id)
        {
            return _context.Vaccines.ToList().Find(x => x.Id == id); 
        }

        public Vaccine UpdateVaccine(int id, Vaccine vaccine)
        {
            var updateVaccine = GetVaccineById(id);
            if (updateVaccine != null)
            {
               // updateVaccine.Producer = vaccine.Producer;
                updateVaccine.Date = vaccine.Date;
                _context.SaveChanges();
            }
            return updateVaccine;
        }
    }
}
