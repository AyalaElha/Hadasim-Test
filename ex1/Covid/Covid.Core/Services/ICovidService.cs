using Covid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Services
{
    public interface ICovidService
    {
        IEnumerable<CovidDetails> GetCovids();
        CovidDetails GetCovidById(int id);
        CovidDetails AddCovid(CovidDetails covid);
        CovidDetails UpdateCovid(int id, CovidDetails covid);
        void DeleteCovid(int id);
    }
}
