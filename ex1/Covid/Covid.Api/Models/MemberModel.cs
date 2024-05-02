namespace Covid.Api.Models
{
    public class MemberModel
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string IdentityNum { get; set; }
        public String? City { get; set; }
        public String? Street { get; set; }
        public int? NumAdress { get; set; }
        public DateTime BirthDay { get; set; }
        public String? Phone { get; set; }
        public String MobilePhone { get; set; }
        public int CovidId { get; set; }
    }
}
