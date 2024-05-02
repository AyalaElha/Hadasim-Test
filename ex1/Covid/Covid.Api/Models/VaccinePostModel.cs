namespace Covid.Api.Models
{
    public class VaccinePostModel
    {
        public DateTime Date { get; set; }
        public int ProducerId { get; set; }
        public int CovidDetailsId { get; set; }
    }
}
