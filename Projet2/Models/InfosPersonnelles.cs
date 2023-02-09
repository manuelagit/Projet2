using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Projet2.Models
{
	public class InfosPersonnelles
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est requis")]
        public string Nom { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le prénom est requis")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "La date de naissance est requise")]
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }

        public int? AdresseId { get; set; } // foreign key
        public Adresse Adresse { get; set; }


    }
}

