using System;
namespace Projet2.Models
{
	public class Utilisateur
	{
        public int Id { get; set; }

        public int? CompteId { get; set; }
        public Compte Compte { get; set; }

        public int? InfosPersonnellesId { get; set; }
        public InfosPersonnelles InfosPersonnelles { get; set; }
    }
}

