using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Projet2.Models
{
	public class InfosClub
	{
        public int Id { get; set; }

        [Display(Name = "Nom du club")]
        [Required(ErrorMessage = "Le nom est requis")]
        public string NomClub { get; set; }

        public int? AdresseId { get; set; } // foreign key
        public Adresse Adresse { get; set; }
    }
}

