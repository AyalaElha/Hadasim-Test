using Covid.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Repositories
{
    public interface ICovidRepository
    {
        IEnumerable<CovidDetails> GetCovids();
        CovidDetails GetCovidById(int id);
        CovidDetails AddCovid(CovidDetails covid);
        CovidDetails UpdateCovid(int id, CovidDetails covid);
        void DeleteCovid(int id);
    }
}
