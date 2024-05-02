using Covid.Core.Entities;
using Covid.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Data.Repositories
{
    public class CovidRepository : ICovidRepository
    {
        private readonly DataContext _context;
        public CovidRepository(DataContext context)
        {
            _context = context;
        }

        public CovidDetails AddCovid(CovidDetails covid)
        {
            var memberOcovid=_context.Members.FirstOrDefault(x=> x.Id == covid.MemberId);
            memberOcovid.CovidDetails=covid;
            _context.Members.Update(memberOcovid); 
            _context.Covids.Add(covid); 
            _context.SaveChanges();
            memberOcovid.CovidDetailsId = covid.Id;
            _context.SaveChanges();
            return covid;
        }

        public void DeleteCovid(int id)
        {
            _context.Covids.Remove(GetCovidById(id));
            _context.SaveChanges();
        }

        public CovidDetails GetCovidById(int id)
        {
            return _context.Covids.ToList().Find(x => x.Id == id);
        }

        public IEnumerable<CovidDetails> GetCovids()
        {
            return _context.Covids.Include(x=>x.Member);
        }

        public CovidDetails UpdateCovid(int id, CovidDetails covid)
        {
            var updateCovid=GetCovidById(id);
            if(updateCovid!=null)
            {
                updateCovid.RecoveryD=covid.RecoveryD;
                updateCovid.PositiveD=covid.PositiveD;  
                updateCovid.numOfVaccine=covid.numOfVaccine;
                _context.SaveChanges();
            }
            return updateCovid; 
        }
    }
}
