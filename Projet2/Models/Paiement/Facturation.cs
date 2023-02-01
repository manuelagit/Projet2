using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Projet2.Models.Paiement
{
    public class Facturation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string NomFacture { get; set; }

        [Required(ErrorMessage = "Le prenom est requis")]
        public string PrenomFacture { get; set; }

        [Required(ErrorMessage = "La ville est requise")]
        public string VilleFacturion { get; set; }

        [Required(ErrorMessage = "L'adresse est requise")]
        public string AdresseFacturation { get; set; }

        [Required(ErrorMessage = "Le code postal est requis")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Entrez un code postal.")]
        public string CodePostaleFacturation { get; set; }

        [Required(ErrorMessage = "Le pays est requis")]
        public string PaysFacturation { get; set; }

        [StringLength(10)]
        public string TelephoneFacturation { get; set; }

        [Required(ErrorMessage = "Le mail est requis")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Entrez un mail valide.")]
        public string AdressEmailFacturation { get; set; }

    }
}
