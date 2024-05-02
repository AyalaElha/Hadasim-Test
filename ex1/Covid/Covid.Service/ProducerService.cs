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
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;    
        }
        public Producer AddProducer(Producer producer)
        {
            if(Validation.CheckProducer(producer))
                    return _producerRepository.AddProducer(producer);   
            return producer;
        }

        public Producer GetProducerById(int id)
        {
           return _producerRepository.GetProducerById(id);
        }

        public IEnumerable<Producer> GetProducers()
        {
          return _producerRepository.GetProducers();
        }

        public Producer UpdateProducer(int id, Producer producer)
        {
            return _producerRepository.UpdateProducer(id, producer);
        }
    }
}
