using System;
namespace Projet2.Models
{
	public class InfosInputClub
	{
        public int Id { get; set; }

        public int? DescritpionClubId { get; set; }
        public string DescritpionClub { get; set; }

        public int? titreClubId { get; set; }
        public string titreClub { get; set; }

        public int? NomLogoId { get; set; }
        public string NomLogo { get; set; }

    }
}

