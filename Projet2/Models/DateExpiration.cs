using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class DateExpiration
    {
        [Required(ErrorMessage = "Le mois d'expiration est requis")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Entrez le mois d'expiration.")]
        public int MoisExpiration { get; set; }

        [Required(ErrorMessage = "L'année d'expiration est requise")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Entrez l'année d'expiration.")]
        public int AnneeExpiration { get; set; }
    }

    public enum MoisExpiration
    {
        [Display(Name ="01")]
        Janvier,
        Fevrier,
        Mars
        

    }
}
