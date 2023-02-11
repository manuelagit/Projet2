using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet2.Models
{
	public class Club
	{
        public int Id { get; set; }

        public int? InfosClubId { get; set; }
        public InfosClub InfosClub { get; set; }

        public int? CompteId { get; set; }
        public Compte Compte { get; set; }

        //public int? AdherentId { get; set; }
        //public Adherent Adherent { get; set; }

        //public int? ListeAdherentId { get; set; }

        //public List<Adherent> ListeAdherent { get; set; }
    }
}

