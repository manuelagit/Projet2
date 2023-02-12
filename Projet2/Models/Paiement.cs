using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Paiement
    {
        public int Id { get; set; }

        [Display(Name = "Numéro de CB")]
        [Required(ErrorMessage = "Le numéro de la carte bleue est requis")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Entrez le numéro de carte bleue.")]
        public string NumeroCB { get; set; }

        [Display(Name = "Date d'expiration")]
        [Required(ErrorMessage = "La date d'expiration est requise")]
        
        public DateTime DateExpiration { get; set; }

        [Display(Name = "Code de sécurité")]
        [Required(ErrorMessage = "Le code de sécurité est requis")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Entrez le code de sécurité.")]
        public int CodeDeSecurite { get; set; }

        public int? FacturationId { get; set; }
        public Facturation Facturation { get; set;}
       
    }
    
}
