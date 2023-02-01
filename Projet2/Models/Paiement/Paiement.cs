using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models.Paiement
{
    public class Paiement
    {
        [Required(ErrorMessage = "Le numéro de la carte bleu est requis")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Entrez le numéro de carte bleu.")]
        public int NumeroCB { get; set; }

        [Required(ErrorMessage = "La date d'expiration est requise")]
        public DateExpiration DateExpiration { get; set; }

        [Required(ErrorMessage = "Le code de sécurité est requis")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Entrez le code de sécurité.")]
        public int CodeDeSecurite { get; set; }
    }
}
