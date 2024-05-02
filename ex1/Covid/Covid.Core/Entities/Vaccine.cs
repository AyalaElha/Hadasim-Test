using Covid.Core.Entities;

namespace Covid.Core
{
    public class Vaccine
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //RelationShips
        //one-to-many
        //Foreign Key
       // public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        //Foreign Key
        public int CovidDetailsId { get; set; }

        public CovidDetails CovidDetails { get; set; }
        public int ProducerId { get; set; }
    }
}
