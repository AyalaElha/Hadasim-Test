using Covid.Core.Entities;
using Covid.Core.Repositories;
using Covid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Service
{
    public class CovidService : ICovidService
    {
        private readonly ICovidRepository _covidRepository;
        public CovidService(ICovidRepository covidRepository)
        {
            _covidRepository = covidRepository;
        }
        public CovidDetails AddCovid(CovidDetails covid)
        {
            if(Validation.CheckCovid(covid))
                 return _covidRepository.AddCovid(covid);
            return covid;
        }

        public void DeleteCovid(int id)
        {
           _covidRepository.DeleteCovid(id);
        }

        public CovidDetails GetCovidById(int id)
        {
            return _covidRepository.GetCovidById(id);
        }

        public IEnumerable<CovidDetails> GetCovids()
        {
            return _covidRepository.GetCovids();
        }

        public CovidDetails UpdateCovid(int id, CovidDetails covid)
        {
           return _covidRepository.UpdateCovid(id, covid);
        }
    }
}
