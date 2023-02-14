using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
    public class Adresse
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Le n° est requis")]
        [Display(Name = "n° ")]
        [RegularExpression(@"^\d(\d)?(\d)?(\d)?$", ErrorMessage = "Entrez un n°.")]
        public int NumeroRue { get; set; }

        //[Required(ErrorMessage = "Le nom de rue est requis")]
        public string NomRue { get; set; }

        [Required(ErrorMessage = "Le code postal est requis")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Entrez un code postal.")]
        public int CodePostal { get; set; }

        [Required(ErrorMessage = "La ville est requise.")]
        [Display(Name = "Ville *")]
        public string NomVille { get; set; }

    }
}

