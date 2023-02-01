using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models.Paiement
{
    public class Paiement
    {
        [Required(ErrorMessage = "Le numéro de la carte bleu est requis")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Entrez le numéro de carte bleu.")]
        public int NumeroCB { get; set; }

        [Required(ErrorMessage = "Le mois d'expiration est requis")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Entrez le mois d'expiration.")]
        public int MoisExpiration { get; set; }

        [Required(ErrorMessage = "L'année d'expiration est requise")]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Entrez l'année d'expiration.")]
        public int AnneExpiration { get; set; }

        [Required(ErrorMessage = "Le code de sécurité est requis")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Entrez le code de sécurité.")]
        public int CodeDeSecurite { get; set; }
    }
}
