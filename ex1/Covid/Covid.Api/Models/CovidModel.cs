namespace Covid.Api.Models
{
    public class CovidModel
    {
        public DateTime? PositiveD { get; set; }
        public DateTime? RecoveryD { get; set; }
        public int numOfVaccine { get; set; }
        public int MemberId { get; set; }//?
    }
}
