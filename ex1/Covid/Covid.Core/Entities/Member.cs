using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string IdentityNum { get; set; }
        public String? City { get; set; }
        public String? Street { get; set; }
        public int? NumAdress { get; set; }
        public DateTime BirthDay { get; set; }
        public String? Phone { get; set; }
        public String MobilePhone { get; set; }
        public CovidDetails CovidDetails { get; set; }

        [ForeignKey("Member")]
        public int? CovidDetailsId { get; set; }

    }
}
