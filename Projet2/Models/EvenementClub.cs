namespace Projet2.Models
{
    public class EvenementClub 
    {
        public int Id { get; set; }

        public int? StageId { get; set; }
        public Stage Stage { get; set; }

        public int? VoyageId { get; set; }
        public Voyage Voyage { get; set; }
    }
}
