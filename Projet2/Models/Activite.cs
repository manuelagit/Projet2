using System;

namespace Projet2.Models
{
    public class Activite
    {
        public int Id { get; set; }
        public int? EvenementClubId { get; set; }
        public EvenementClub EvenementClub { get; set; }

        public int? SortieAdherentId { get; set; }
        public SortieAdherent SortieAdherent { get; set; }
    }
}
