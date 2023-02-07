using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Facturation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string NomFacturation { get; set; }

        [Required(ErrorMessage = "Le prenom est requis")]
        public string PrenomFacturation { get; set; }

        [Required(ErrorMessage = "La ville est requise")]
        public string VilleFacturation { get; set; }

        [Required(ErrorMessage = "L'adresse est requise")]
        public string AdresseFacturation { get; set; }

        [Required(ErrorMessage = "Le code postal est requis")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Entrez un code postal.")]
        public string CodePostalFacturation { get; set; }

        [Required(ErrorMessage = "Le pays est requis")]
        public string PaysFacturation { get; set; }

        [StringLength(10)]
        public string TelephoneFacturation { get; set; }

        
    }
}
