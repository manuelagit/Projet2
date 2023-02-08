using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Facturation
    {
        public int Id { get; set; }

        [Display(Name = "Nom de l'acheteur")]
        [Required(ErrorMessage = "Le nom est requis")]
        public string NomFacturation { get; set; }

        [Display(Name = "Prénom de l'acheteur")]
        [Required(ErrorMessage = "Le prenom est requis")]
        public string PrenomFacturation { get; set; }

        [Display(Name = "Ville")]
        [Required(ErrorMessage = "La ville est requise")]
        public string VilleFacturation { get; set; }

        [Display(Name = "Adresse de Facturation")]
        [Required(ErrorMessage = "L'adresse est requise")]
        public string AdresseFacturation { get; set; }

        [Display(Name = "Code Postal")]
        [Required(ErrorMessage = "Le code postal est requis")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Entrez un code postal.")]
        public string CodePostalFacturation { get; set; }

        [Display(Name = "Pays")]
        [Required(ErrorMessage = "Le pays est requis")]
        public string PaysFacturation { get; set; }

        [Display(Name = "Numero de téléphone")]
        [StringLength(10)]
        public string TelephoneFacturation { get; set; }

        public int? ClubId { get; set; }
        public Club Club { get; set; }
    }
}
