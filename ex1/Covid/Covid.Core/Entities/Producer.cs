using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Entities
{
    public class Producer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Boolean Status { get; set; }
        
        public List<Vaccine> Vaccines { get; set; }
    }
}
