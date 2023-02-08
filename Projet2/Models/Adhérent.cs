namespace Projet2.Models
{
    public class Adhérent
    {
        public int Id { get; set; }
        public int? ClubId { get; set; }
        public Club Club { get; set; }

        public int CompteId { get; set; }
        public Compte Compte { get; set; }
    }
}
