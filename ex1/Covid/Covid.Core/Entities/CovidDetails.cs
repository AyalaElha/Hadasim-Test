using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Entities
{
    public class CovidDetails
    {
        
        public int Id { get; set; }
        public DateTime? PositiveD { get; set; }
        public DateTime? RecoveryD { get; set; }
        public int numOfVaccine { get; set; }

        public Member Member { get; set; }

        [ForeignKey("CovidDetails")]
        public int MemberId { get; set; }


        public List<Vaccine> Vaccines { get; set; }
    }
}
