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
    public class ProducerRepository : IProducerRepository
    {
        private readonly DataContext _context;
        public ProducerRepository(DataContext context)
        {
            _context = context;
        }
        public Producer AddProducer(Producer producer)
        {
           _context.Producers.Add(producer);
            _context.SaveChanges();
            return producer;
        }

        public Producer GetProducerById(int id)
        {
            return _context.Producers.ToList().Find(x => x.Id == id);
        }

        public IEnumerable<Producer> GetProducers()
        {
           return _context.Producers.Include(x=>x.Vaccines);   
        }

        public Producer UpdateProducer(int id, Producer producer)
        {
            var updateProducer=GetProducerById(id); 
            if(updateProducer != null)
            {
                updateProducer.Name = producer.Name;    
                updateProducer.Status = producer.Status;
                _context.SaveChanges();
            }
            return updateProducer;
        }
    }
}
