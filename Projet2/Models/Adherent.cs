namespace Projet2.Models
{
    public class Adherent
    {
        public int Id { get; set; }
        public int? ClubId { get; set; }
        public Club Club { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
