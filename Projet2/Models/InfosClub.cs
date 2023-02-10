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

        public int? DescritpionClubId { get; set; }
        [Display(Name = "Courte description")]
        //[Required(ErrorMessage = "Entrez une courte description")]
        public string DescritpionClub { get; set; }

        public int? titreClubId { get; set; }
        [Display(Name = "Titre de votre page")]
        //[Required(ErrorMessage = "Entrez un titre")]
        public string titreClub { get; set; }

        public int? urlLogoId { get; set; }
        public string urlLogo { get; set; }
    }
}

