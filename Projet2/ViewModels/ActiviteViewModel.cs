using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class ActiviteViewModel
    {
        public Activite Activite { get; set; }
        public List<Activite> Activites { get; set; }

        public SortieAdherent SortieAdherent { get; set; }
        public List<SortieAdherent> SortieAdherents { get; set; }

        public EvenementClub EvenementClub { get; set; }

        public List<EvenementClub> EvenementClubs { get; set; }

    }
}
