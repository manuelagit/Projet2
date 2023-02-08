using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Projet2.Models
{
	public class Compte
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Le mail est requis")]
        [Display(Name = "Adresse Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Entrez un mail.")]
        public string AdressEmail { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
        
        public int? FacturationId { get; set; }
        public Facturation Facturation { get; set;}
        public int? PaiementId { get;}
        public Paiement paiement { get; set; }

    }
}

