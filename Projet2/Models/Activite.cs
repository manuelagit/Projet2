using System;

namespace Projet2.Models
{
    public class Activite
    {
        public int Id { get; set; }

        public string TypeActivite { get; set; }

        public string NomActivite { get; set; }

        public string DateActivite { get; set; }

        public string DescriptionActivite { get; set; }
        public string LieuActivite { get; set; }

        public int NombrePlaceActivite { get; set; }

        public int? ClubId { get; set; }
        public Club Club { get; set; }

        public int? EvenementClubId { get; set; }
        public EvenementClub EvenementClub { get; set; }

        public int? SortieAdherentId { get; set; }
        public SortieAdherent SortieAdherent { get; set; }
    }
}
