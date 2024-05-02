using Covid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Repositories
{
    public interface IProducerRepository
    {
        IEnumerable<Producer> GetProducers();
        Producer GetProducerById(int id);   
        Producer AddProducer (Producer producer);
        Producer UpdateProducer(int id, Producer producer);   
        
    }
}
