namespace Projet2.Models
{
    public class Admin 
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public bool IsAdmin { get; set; }
    }
}
