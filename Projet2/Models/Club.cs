using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet2.Models
{
	public class Club
	{
        public int Id { get; set; }

        public int? InfosClubId { get; set; }
        public InfosClub InfosClub { get; set; }

        public int? CompteId { get; set; }
        public Compte Compte { get; set; }

        [NotMapped] // is not added to the db
        public string Name { get; set; }

        //public int? AdherentId { get; set; }
        //public Adherent Adherent { get; set; }

        //public int? ListeAdherentId { get; set; }

        //public List<Adherent> ListeAdherent { get; set; }
    }
}

